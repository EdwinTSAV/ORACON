function checkOffset() {
    if ($('#deslizable').offset().top + $('#deslizable').height() >=
        $('#footer').offset().top - 10)
        $('#deslizable').css('position', 'absolute');
    if ($(document).scrollTop() + window.innerHeight < $('#footer').offset().top)
        $('#deslizable').css('position', 'fixed');
}
$(document).scroll(function () {
    checkOffset();
});

function video(idClase) {
    var $videoSeccion = $('div#video');
    var $logged = $('#logged');
    $.ajax({
        'url': '/Curso/Video?idClase=' + idClase,
        'type': 'get'
    }).done(function (items) {
        var options = `<iframe width="1018" height="600" src="${items.video}" 
        title = "YouTube video player" frameborder="0" allow="accelerometer;
        autoplay; clipboard-write; encrypted-media; gyroscope;
        picture-in-picture" allowfullscreen></iframe>
            <h1>${items.nombre}</h1>
            <p>${items.descripcion}</p>`;
            
        if (Object.values($logged).length > 0 && items.recursos.length > 0) {
            options += `<h1>Recursos</h1>`
            for (var i = 0; i < items.recursos.length; i++) {
                options += `<ul>
                                <li>
                                    <i class="fa fa-download" aria-hidden="true"></i><a href="${items.recursos[i].archivo}"> ${items.recursos[i].archivo}</a>
                                </li>
                            </ul>`
            }
        } else if (Object.values($logged).length <= 0){
            options += `<p class="text-danger">Para visualizar los recursos de esta seccion <a href="/User/Login"><strong class="text-danger">logeate</strong></a></p>`
        }
        $videoSeccion.html(options);
    })
}
