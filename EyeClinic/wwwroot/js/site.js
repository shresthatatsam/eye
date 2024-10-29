
    document.addEventListener("DOMContentLoaded", function() {
        const slideElements = document.querySelectorAll('.slide-up');

    function checkVisibility() {
            const windowHeight = window.innerHeight;

            slideElements.forEach(element => {
                const elementTop = element.getBoundingClientRect().top;

    if (elementTop < windowHeight - 100) {
        element.classList.add('visible');
                } else {
        element.classList.remove('visible');
                }
            });
        }

    window.addEventListener('scroll', checkVisibility);
    window.addEventListener('resize', checkVisibility);

    // Initial check
    checkVisibility();
    });
