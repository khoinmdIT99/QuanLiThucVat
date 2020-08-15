$(document).ready(function () {
    $("#flexiselDemo1").flexisel({

        visibleItems: 4,
        animationSpeed: 700,
        autoPlay: false,
        autoPlaySpeed: 2000,
        pauseOnHover: true,
        enableResponsiveBreakpoints: true,
        responsiveBreakpoints: {
            portrait: {
                changePoint: 575,
                visibleItems: 1
            },
            landscape: {
                changePoint: 767,
                visibleItems: 2
            },
            tablet: {
                changePoint: 991,
                visibleItems: 3
            },
            minilaptop: {
                changePoint: 1199,
                visibleItems: 3
            }
        }
    });

});