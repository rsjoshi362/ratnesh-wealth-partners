(function ($) {
    "use strict";

    // Initiate the wowjs
    new WOW().init();

    // Sticky Navbar
    $(window).on("scroll", function () {
        if ($(this).scrollTop() > 185.46875) {
            $('.sticky-top').css('position', 'fixed');
        } else {
            $('.sticky-top').css('position', 'sticky');
        }
    });

    // Back to top button
    $(window).on("scroll", function () {
        if ($(this).scrollTop() > 300) {
            $(".back-to-top").fadeIn("fast");
        } else {
            $(".back-to-top").fadeOut("fast");
        }
    });

    $(".back-to-top").on("click", function () {
        $("html, body").animate({ scrollTop: 0 }, 1500, "easeInOutExpo");
        return false;
    });

    // Facts counter
    $('[data-toggle="counter-up"]').counterUp({
        delay: 10,
        time: 2000,
    });

    // Skills
    $(".skill").waypoint(function () {
        $(".progress .progress-bar").each(function () {
            $(this).css("width", $(this).attr("aria-valuenow") + "%");
        });
    },
        { offset: "80%" }
    );

    OwlCarouselInIt();

    SetActiveMenu();
    OfferingMenuInIt();
    ContactUsValidation();
})(jQuery);

function OfferingMenuInIt() {
    var $subMenuContainer = $(".sub-menu-container");
    var $mainMenuContainer = $(".menu-column");
    $(".menu-column .menu-item").on("mouseenter mouseleave",
        function () {
            let dataTarget = $(this).attr("data-target");
            $(".sub-menu").hide();
            $(".menu-column .menu-item").removeClass("selected");
            $subMenuContainer.find(".sub-menu[data-menu=" + dataTarget + "]").show();
        }
    );

    $(".sub-menu-container .sub-menu").on("mouseenter mouseleave",
        function () {
            let dataMenu = $(this).attr("data-menu");
            $(".menu-column .menu-item").removeClass("selected");
            $mainMenuContainer
                .find(".menu-item[data-target=" + dataMenu + "]")
                .addClass("selected");
        }
    );
}

function ContactUsValidation() {
    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.querySelectorAll(".needs-validation");

    // Loop over them and prevent submission
    Array.prototype.slice.call(forms).forEach(function (form) {
        form.addEventListener(
            "submit",
            function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault();
                    event.stopPropagation();
                }

                form.classList.add("was-validated");
            },
            false
        );
    });
}

function SetActiveMenu() {
    // Get the current pathname
    const currentPath = window.location.pathname;
    //console.log("currentPath: ", currentPath);
    let navLinks = {
        home: "linkHome",
        about: "linkAbout",
        contact: "linkContact",
        "kyc-fatca-forms": "linkKYCFatcaForms",
        offering: "linkOffering",
        "why-choose-us": "linkwhy-choose-us",
        calculators: "linkCalculators",
    };

    // Loop through the mapping and check if the path is in the current pathname
    if (
        currentPath === "/" ||
        currentPath === "/Index.aspx" ||
        currentPath === "/home"
    ) {
        const linkElement = document.getElementById(navLinks.home);
        if (linkElement) {
            linkElement.classList.add("active");
        }
    } else {
        for (const [path, id] of Object.entries(navLinks)) {
            /*console.log("path: ", path);*/
            if (currentPath.includes(path)) {
                const linkElement = document.getElementById(id);
                if (linkElement) {
                    linkElement.classList.add("active");
                }
            }
        }
    }
}

function OwlCarouselInIt() {
    // Project carousel
    $(".project-carousel").owlCarousel({
        autoplay: true,
        smartSpeed: 1000,
        margin: 25,
        loop: true,
        nav: false,
        dots: true,
        dotsData: true,
        responsive: {
            0: {
                items: 1,
            },
            768: {
                items: 2,
            },
            992: {
                items: 3,
            },
            1200: {
                items: 4,
            },
        },
    });

    // Testimonials carousel
    $(".testimonial-carousel").owlCarousel({
        autoplay: true,
        smartSpeed: 1000,
        margin: 25,
        loop: true,
        center: true,
        dots: false,
        nav: true,
        navText: [
            '<i class="bi bi-chevron-left"></i>',
            '<i class="bi bi-chevron-right"></i>',
        ],
        responsive: {
            0: {
                items: 1,
            },
            768: {
                items: 2,
            },
            992: {
                items: 3,
            },
        },
    });
}

const navContainer = document.getElementById("navContainer");
function openNavBox() {
    navContainer.classList.add("show");
}

function closeNavBox() {
    navContainer.classList.remove("show", "collapse");
}
