// Search functionality - shared across all documents
document.addEventListener('DOMContentLoaded', function () {
    // Create search box
    const searchContainer = document.createElement('div');
    searchContainer.className = 'search-container';
    searchContainer.innerHTML = `
        <div class="search-box">
            <input type="text" id="searchInput" placeholder="Search in document...">
            <span class="result-count" id="resultCount"></span>
        </div>
    `;
    document.body.insertBefore(searchContainer, document.body.firstChild);

    const searchInput = document.getElementById('searchInput');
    const resultCount = document.getElementById('resultCount');
    const pages = document.querySelectorAll('.page');
    const originalContents = [];

    // Store original content
    pages.forEach(page => originalContents.push(page.innerHTML));

    searchInput.addEventListener('input', function () {
        const keyword = this.value.trim();

        pages.forEach((page, index) => {
            page.innerHTML = originalContents[index];
        });

        resultCount.textContent = '';

        if (keyword === '') {
            reattachPaginationListeners();
            return;
        }

        const regex = new RegExp(`(${escapeRegex(keyword)})`, 'gi');
        let totalMatches = 0;
        let firstMatchPage = -1;

        pages.forEach((page, pageIndex) => {
            const matches = highlightInPage(page, regex);
            if (matches > 0) {
                totalMatches += matches;
                if (firstMatchPage === -1) firstMatchPage = pageIndex;
            }
        });

        reattachPaginationListeners();

        if (totalMatches > 0) {
            showPage(firstMatchPage);
            const allMarks = document.querySelectorAll('mark');
            if (allMarks.length > 0) {
                allMarks[0].classList.add('first');
                allMarks[0].scrollIntoView({ behavior: 'smooth', block: 'center' });
            }
            resultCount.textContent = `${totalMatches} result${totalMatches !== 1 ? 's' : ''} found`;
        } else {
            resultCount.textContent = 'No results';
        }
    });

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
            } else if (node.nodeType === 1 && node.tagName !== 'SCRIPT' && node.tagName !== 'STYLE') {
                Array.from(node.childNodes).forEach(child => highlightInNode(child));
            }
        }
        highlightInNode(page);
        return matches;
    }

    function reattachPaginationListeners() {
        document.querySelectorAll('.prevBtn').forEach(btn => {
            btn.addEventListener('click', () => {
                if (window.currentPage > 0) showPage(window.currentPage - 1);
            });
        });
        document.querySelectorAll('.nextBtn').forEach(btn => {
            btn.addEventListener('click', () => {
                if (window.currentPage < pages.length - 1) showPage(window.currentPage + 1);
            });
        });
    }

    function showPage(pageIndex) {
        pages.forEach((page, index) => {
            page.classList.toggle('active', index === pageIndex);
        });
        window.currentPage = pageIndex;
    }

    function escapeRegex(string) {
        return string.replace(/[.*+?^${}()|[\]\\]/g, '\\$&');
    }
});