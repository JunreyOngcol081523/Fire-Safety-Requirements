document.addEventListener('DOMContentLoaded', function () {
    let currentPage = 0;
    const pages = document.querySelectorAll('.page');
    let nextButtons = document.querySelectorAll('.nextBtn');
    let prevButtons = document.querySelectorAll('.prevBtn');

    // Search elements
    const searchInput = document.getElementById('searchInput');
    const resultCount = document.getElementById('resultCount');
    const originalContents = [];

    // Store original content for each page
    pages.forEach(page => {
        originalContents.push(page.innerHTML);
    });

    // Search event listener
    if (searchInput) {
        searchInput.addEventListener('input', function () {
            performSearch(this.value.trim());
        });

        searchInput.addEventListener('search', function () {
            performSearch(this.value.trim());
        });
    }

    function performSearch(keyword) {
        // Reset all pages to original content
        pages.forEach((page, index) => {
            page.innerHTML = originalContents[index];
        });

        if (resultCount) resultCount.textContent = '';

        if (!keyword) {
            reattachEventListeners();
            updateButtonState();
            return;
        }

        const regex = new RegExp(`(${escapeRegex(keyword)})`, 'gi');
        let totalMatches = 0;
        let firstMatchPage = -1;

        // Highlight in all pages
        pages.forEach((page, pageIndex) => {
            const matches = highlightInPage(page, regex);
            if (matches > 0) {
                totalMatches += matches;
                if (firstMatchPage === -1) {
                    firstMatchPage = pageIndex;
                }
            }
        });

        reattachEventListeners();
        updateButtonState();

        if (totalMatches > 0 && firstMatchPage !== -1) {
            // Navigate to first match
            pages[currentPage].classList.remove('active');
            currentPage = firstMatchPage;
            pages[currentPage].classList.add('active');
            updateButtonState();

            // Mark and scroll to first occurrence
            setTimeout(() => {
                const allMarks = document.querySelectorAll('mark');
                if (allMarks.length > 0) {
                    allMarks[0].classList.add('first');
                    allMarks[0].scrollIntoView({ behavior: 'smooth', block: 'center' });
                }
            }, 100);

            if (resultCount) {
                resultCount.textContent = `${totalMatches} result${totalMatches !== 1 ? 's' : ''}`;
            }
        } else {
            if (resultCount) resultCount.textContent = 'No results';
        }
    }

    function highlightInPage(page, regex) {
        let matches = 0;

        function highlightInNode(node) {
            if (node.nodeType === 3) {
                const text = node.textContent;
                if (regex.test(text)) {
                    const span = document.createElement('span');
                    span.innerHTML = text.replace(regex, '<mark>$1</mark>');
                    node.parentNode.replaceChild(span, node);
                    matches += (text.match(regex) || []).length;
                }
            } else if (node.nodeType === 1 && node.tagName !== 'SCRIPT' && node.tagName !== 'STYLE' && node.tagName !== 'BUTTON') {
                Array.from(node.childNodes).forEach(child => highlightInNode(child));
            }
        }

        highlightInNode(page);
        return matches;
    }

    function escapeRegex(string) {
        return string.replace(/[.*+?^${}()|[\]\\]/g, '\\$&');
    }

    function goToNextPage() {
        pages[currentPage].classList.remove('active');
        currentPage = (currentPage + 1) % pages.length;
        pages[currentPage].classList.add('active');
        updateButtonState();
    }

    function goToPreviousPage() {
        pages[currentPage].classList.remove('active');
        currentPage = (currentPage - 1 + pages.length) % pages.length;
        pages[currentPage].classList.add('active');
        updateButtonState();
    }

    function updateButtonState() {
        prevButtons.forEach(button => {
            button.disabled = (currentPage === 0);
        });

        nextButtons.forEach(button => {
            button.disabled = (currentPage === pages.length - 1);
        });
    }

    function reattachEventListeners() {
        nextButtons = document.querySelectorAll('.nextBtn');
        prevButtons = document.querySelectorAll('.prevBtn');

        nextButtons.forEach(button => {
            const newButton = button.cloneNode(true);
            button.parentNode.replaceChild(newButton, button);
        });

        prevButtons.forEach(button => {
            const newButton = button.cloneNode(true);
            button.parentNode.replaceChild(newButton, button);
        });

        nextButtons = document.querySelectorAll('.nextBtn');
        prevButtons = document.querySelectorAll('.prevBtn');

        nextButtons.forEach(button => {
            button.addEventListener('click', goToNextPage);
        });

        prevButtons.forEach(button => {
            button.addEventListener('click', goToPreviousPage);
        });
    }

    nextButtons.forEach(button => {
        button.addEventListener('click', goToNextPage);
    });

    prevButtons.forEach(button => {
        button.addEventListener('click', goToPreviousPage);
    });

    updateButtonState();
});