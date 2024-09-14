const worker = new SharedWorker('/shared-worker-signalr.js');

// Start communication with the shared worker
worker.port.start();

worker.port.onmessage = function (event) {
    if (event.data.type === 'CONNECTED') {
        console.log("SignalR is connected.");
    } else if (event.data.type === 'DISCONNECTED') {
        console.log("SignalR is disconnected.");
    } else if (event.data.type === 'MESSAGE_SENT') {
        console.log("Message sent:", event.data.message);
    } else if (event.data.type === 'ERROR') {
        console.error("Error:", event.data.error);
    } else if (event.data.type === 'ALREADY_CONNECTED') {
        console.log("SignalR is already connected.");
    } else if (event.data.type === 'NOT_CONNECTED') {
        console.log("SignalR is not connected.");
    }
};

// Start the SignalR connection
function startConnection() {
    worker.port.postMessage({ type: 'START_CONNECTION' });
}

// Stop the SignalR connection
function stopConnection() {
    worker.port.postMessage({ type: 'STOP_CONNECTION' });
}

// Send a message via SignalR
function sendMessage(message) {
    worker.port.postMessage({ type: 'SEND_MESSAGE', message: message });
}
