let connection = null; // Connection is initialized to null when the worker is first created

onconnect = function (event) {
    const port = event.ports[0];

    port.onmessage = async function (event) {
        if (event.data.type === 'START_CONNECTION') {
            if (!connection) {
                // Only start a new connection if one doesn't already exist
                connection = new signalR.HubConnectionBuilder()
                    .withUrl("/yourHubEndpoint")
                    .configureLogging(signalR.LogLevel.Information)
                    .build();

                try {
                    await connection.start();
                    console.log("SignalR Connected");
                    port.postMessage({ type: 'CONNECTED' });
                } catch (err) {
                    console.log("Error connecting to SignalR:", err);
                    port.postMessage({ type: 'ERROR', error: err.toString() });
                }
            } else {
                // Connection already exists, notify the port
                port.postMessage({ type: 'ALREADY_CONNECTED' });
            }
        } else if (event.data.type === 'STOP_CONNECTION') {
            if (connection) {
                try {
                    await connection.stop();
                    console.log("SignalR Disconnected");
                    connection = null; // Reset connection to null after stopping it
                    port.postMessage({ type: 'DISCONNECTED' });
                } catch (err) {
                    console.log("Error disconnecting SignalR:", err);
                    port.postMessage({ type: 'ERROR', error: err.toString() });
                }
            } else {
                // No connection to stop, notify the port
                port.postMessage({ type: 'NOT_CONNECTED' });
            }
        } else if (event.data.type === 'SEND_MESSAGE') {
            if (connection && connection.connectionState === "Connected") {
                try {
                    await connection.invoke("SendMessage", event.data.message);
                    port.postMessage({ type: 'MESSAGE_SENT', message: event.data.message });
                } catch (err) {
                    console.log("Error sending message:", err);
                    port.postMessage({ type: 'ERROR', error: err.toString() });
                }
            } else {
                // Cannot send message because the connection is not active
                port.postMessage({ type: 'NOT_CONNECTED' });
            }
        }
    };
};
