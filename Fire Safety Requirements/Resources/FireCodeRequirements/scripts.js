document.addEventListener('DOMContentLoaded', function () {
    let currentPage = 0;
    const pages = document.querySelectorAll('.page');
    const nextButtons = document.querySelectorAll('.nextBtn'); // Select all "Next" buttons
    const prevButtons = document.querySelectorAll('.prevBtn'); // Select all "Previous" buttons

    // Function to go to the next page
    function goToNextPage() {
        // Hide the current page
        pages[currentPage].classList.remove('active');

        // Increment the page index, wrapping around if necessary
        currentPage = (currentPage + 1) % pages.length;

        // Show the next page
        pages[currentPage].classList.add('active');

        updateButtonState(); // Update button state after page change
    }

    // Function to go to the previous page
    function goToPreviousPage() {
        // Hide the current page
        pages[currentPage].classList.remove('active');

        // Decrement the page index, wrapping around if necessary
        currentPage = (currentPage - 1 + pages.length) % pages.length;

        // Show the previous page
        pages[currentPage].classList.add('active');

        updateButtonState(); // Update button state after page change
    }

    // Function to update the state of the buttons (enable/disable)
    function updateButtonState() {
        // Disable previous button on the first page
        prevButtons.forEach(button => {
            if (currentPage === 0) {
                button.disabled = true;
            } else {
                button.disabled = false;
            }
        });

        // Disable next button on the last page
        nextButtons.forEach(button => {
            if (currentPage === pages.length - 1) {
                button.disabled = true;
            } else {
                button.disabled = false;
            }
        });
    }

    // Attach the goToNextPage function to each "Next" button
    nextButtons.forEach(button => {
        button.addEventListener('click', goToNextPage);
    });

    // Attach the goToPreviousPage function to each "Previous" button
    prevButtons.forEach(button => {
        button.addEventListener('click', goToPreviousPage);
    });

    // Initialize button state when the page loads
    updateButtonState();
});