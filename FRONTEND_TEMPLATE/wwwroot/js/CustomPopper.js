// Select all popper buttons
const popperButtons = document.querySelectorAll(".popper-button");

// Function to create popper instance
function createInstance(popperButton, popperPopup) {
    return Popper.createPopper(popperButton, popperPopup, {
        placement: "bottom", // preferred placement of popper
        modifiers: [
            {
                name: "offset", // offsets popper from the reference/button
                options: {
                    offset: [0, 8],
                },
            },
            {
                name: "flip", // flips popper with allowed placements
                options: {
                    allowedAutoPlacements: ["right", "left", "top", "bottom"],
                    rootBoundary: "viewport",
                },
            },
        ],
    });
}

// Function to show popper
function showPopper(popperPopup, popperArrow, popperInstance) {
    popperPopup.setAttribute("show-popper", "");
    popperArrow.setAttribute("data-popper-arrow", "");
    if (!popperInstance) {
        popperInstance = createInstance(popperPopup.previousElementSibling, popperPopup);
    }
}

// Function to hide popper
function hidePopper(popperPopup, popperArrow, popperInstance) {
    popperPopup.removeAttribute("show-popper");
    popperArrow.removeAttribute("data-popper-arrow");
    if (popperInstance) {
        popperInstance.destroy();
    }
}

// Event handlers object
const eventHandlers = {
    click: (button, popperPopup, popperArrow) => {
        let popperInstance = null;

        button.addEventListener("click", (e) => {
            e.preventDefault();
            if (popperPopup.hasAttribute("show-popper")) {
                hidePopper(popperPopup, popperArrow, popperInstance);
                popperInstance = null;
            } else {
                showPopper(popperPopup, popperArrow, popperInstance);
            }
        });
    },

    hover: (button, popperPopup, popperArrow) => {
        let popperInstance = null;

        button.addEventListener("mouseenter", () => {
            showPopper(popperPopup, popperArrow, popperInstance);
        });

        button.addEventListener("mouseleave", () => {
            hidePopper(popperPopup, popperArrow, popperInstance);
            popperInstance = null;
        });

        popperPopup.addEventListener("mouseenter", () => {
            showPopper(popperPopup, popperArrow, popperInstance);
        });

        popperPopup.addEventListener("mouseleave", () => {
            hidePopper(popperPopup, popperArrow, popperInstance);
            popperInstance = null;
        });
    },
};

// Add event listeners to buttons based on their data-event attribute
popperButtons.forEach((button) => {
    const event = button.getAttribute("data-event");
    const popperPopup = button.nextElementSibling;
    const popperArrow = popperPopup.querySelector(".popper-arrow");

    // Check if the event type exists in the eventHandlers object
    if (eventHandlers[event]) {
        eventHandlers[event](button, popperPopup, popperArrow);
    }
});
