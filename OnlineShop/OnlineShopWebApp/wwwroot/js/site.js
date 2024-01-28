window.addEventListener('scroll', function () {
    document.getElementById('header-nav').classList.toggle('headernav-scroll', window.scrollY > 134)
})

const offcanvasCartEl = document.getElementById('offcanvasCart');
const offcanvasCart = new bootstrap.Offcanvas(offcanvasCartEl);

document.querySelectorAll('.closecart').forEach(item => {
    item.addEventListener('click', (e) => {
        e.preventDefault();
        offcanvasCart.hide();
    });
});

$(document).ready(function () {
    $(window).scroll(function () {
        if ($(this).scrollTop() > 300) {
            $('#top').fadeIn();
        }
        else {
            $('#top').fadeOut();
        }
    });

    $('#top').click(function () {
        $('html, body').animate({
            scrollTop: 0
        }, 500);
        return false;
    })
});

$(document).ready(function () {
    $(".owl-carousel-full").owlCarousel({
        /*loop:true,*/
        margin: 10,
        responsive: {
            0: {
                items: 1
            },
            500: {
                items: 2
            },
            750: {
                items: 3
            },
            1000: {
                items: 4
            },
            1440:
            {
                items: 5
            },
            1920:
            {
                items: 6
            }
        }
    });
});