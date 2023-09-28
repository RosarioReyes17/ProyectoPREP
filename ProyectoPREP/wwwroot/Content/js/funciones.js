var URL = window.location.origin+'/mediclab2/';
var activeurl = window.location;

$( document ).ready(function() {
   console.log( "SIRPAFF READY!" );
$('a[href="'+activeurl+'"]').addClass('active');

$(".delete").click( function(e) {
  e.preventDefault();
  var url = this.href;
  var confirmacion=confirm('Estas seguro que deseas eliminar este registro?');
  if (confirmacion) {
  	location.href = url;
  }
});


$(document).on('submit', '.ajaxform', function(){
    event.preventDefault();
    var action = $(this).attr('action');
    var parametros = new FormData($(this)[0]);
    $.ajax({
        url: action,
        data: parametros,
        type: "POST",
        contentType: false,
        processData: false,
        beforeSend: function(){
          document.getElementById("loading").style.opacity="1";
        },
        success: function(datos){
          $('#notify').html(datos);
          document.getElementById("loading").style.opacity="0";
        }
    });
});

$(function(){
     $('a[href*=#]').click(function() {
     if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'')
         && location.hostname == this.hostname) {
             var $target = $(this.hash);
             $target = $target.length && $target || $('[name=' + this.hash.slice(1) +']');
             if ($target.length) {
                 var targetOffset = $target.offset().top -100;
                 $('html,body').animate({scrollTop: targetOffset}, 1000)
                 return false;
            }
       }
   });
});

$(document).on('click', '.ajax', function(){
        event.preventDefault();
        var ruta = $(this).attr('href');

        $.ajax({
        url : ruta,
        beforeSend : function(){
          document.getElementById("loadingweb").style.display="flex";
        },
        success : function(datos){
          $(".container").html(datos);
          document.getElementById("loadingweb").style.display="none";
        }
   });
});
new WOW().init();

      $('#campobuscar').focus(function(){
        $('#menuenlaces').hide();
        $('#bresultados').show();
      });

      $(document).click(function(event){
        console.log(event);
        if (event.target.id!=='campobuscar' && event.target.id!=='bajax' && event.target!=='pacientes') {
          $('#bresultados').hide();
          $('#menuenlaces').show();
        }
      });


      // controlador de tiempo de cada tecla
      var controladorTiempo = '';

      function codigoAJAX(){
        var busqueda = $('#campobuscar').val();
         if (busqueda!=='') {
            $('#brapido').hide();
            $('#bajax').show();
            $('#bhead').show();
            $.ajax({
                url: URL+'views/mt/getPACIENTES.php',
                data: {busqueda:busqueda},
                dataType: 'html',
                type: "POST",
                beforeSend: function(){
                  $('#bbusqueda').html(busqueda);
                  $('#bajax').html('<div class="bold">Cargando...</div>');
                },
                success: function(datos){
                  $('#bajax').html(datos);
                }
            });
         }else{
           $('#bhead').hide();
           $('#bajax').hide();
           $('#brapido').show();
         }
      }

      $('#buscador').keyup(function(){
        clearTimeout(controladorTiempo);
        controladorTiempo = setTimeout(codigoAJAX, 350);
      });

      $('#buscador').submit(function(){
        event.preventDefault();
      });



$(document).on('click', '.btn-modal', function(e){
    // valor de la ruta
    var ruta = $(this).attr('ruta');
    var cedula = $(this).attr('data-source'); 

    $.ajax({
      url: URL+ruta,
      type: 'POST',
      dataType: 'html',
      data: {cedula: cedula},
      beforeSend : function(){
        $('#loadingweb').css('display', 'flex');
      },
      success: function(datos) {
        $('#modal > .caja').html(datos);
        $('#loadingweb').css('display', 'none');
        $('#modal').css('display', 'flex');
        $('#modal').animate({'opacity':'1'}, 200);
      }
    });
});


$('#modal').click(function(event){
  if (event.target.id=='modal') {
    $('#modal').animate({'opacity':'0'}, 200);
      setTimeout(function(){
        $('#modal').css('display', 'none');
        $('#modal > div').html('');
      }, 200);
  }
});

  $('img[data-original]').each(function(e){
    $(this).attr('src', $(this).attr('data-original'));
    $(this).load(function(){
      $(this).removeAttr('data-original');
    });
  });

});


function validar_cedula(ced) {
    var c = ced.replace(/-/g,'');
    var Cedula = c.substr(0, c.length - 1);
    var Verificador = c.substr(c.length - 1, 1);
    var suma = 0;
    if(ced.length < 13) { return false; }
    for (i=0;i < Cedula.length;i++) {
        mod = "";
         if((i % 2) == 0){mod = 1} else {mod = 2}
         res = Cedula.substr(i,1) * mod;
         if (res > 9) {
              res = res.toString();
              uno = res.substr(0,1);
              dos = res.substr(1,1);
              res = eval(uno) + eval(dos);
         }
         suma += eval(res);
    }
    el_numero = (10 - (suma % 10)) % 10;
    if (el_numero == Verificador && Cedula.substr(0,3) != "000") {
      return true;
    }
    else   {
      return false
    }
}


  function getSELECT(tabla, id, selector){
      $.ajax({
        url: URL+"views/query/getSELECT.php",
        cache:false,
        type:"POST",
        dataType: 'json',
        data:{id:id},
        beforeSend: function(){
          $('#loadingweb').css('display', 'flex');
        },
        success : function(datos){
          var $select = $('#'+selector);
          $select.html('');
          $.each(datos, function(id, name) {
            $select.append('<option value=' + name.id + '>' + name.name + '</option>');
          });

          $('#loadingweb').css('display', 'none');
          $('#centrodesalud').change();
        }
      });
    }


  function consultacedula(){
    event.preventDefault();
    var cedula=$("#cedula").val();
    if (validar_cedula(cedula)==true) {
      /*SI LA CEDULA ES VALIDA*/
      console.log('cedula valida');
      $.ajax({
          url: URL+"views/mt/getPADRON.php",
          cache:false,
          type:"POST",
          dataType: 'json',
          data:{cedula:cedula},
          beforeSend: function(){
            $('#loadingweb').css('display', 'flex');
          },
          success: function(datos){
            $('#notify').html(datos);
            $('input[name="nombres"]').val(datos.NOMBRES);
            $('input[name="apellidos"]').val(datos.APELLIDO1+' '+datos.APELLIDO2);
            $('input[name="fechanacimiento"]').val(datos.FECHA_NAC);
            $('input[name="telefono"]').val(datos.TELEFONO);
            $('#estadocivil > option[value="'+datos.EST_CIVIL+'"]').selected();
            $('#sexo > option[value="'+datos.CED_A_SEXO+'"]').selected();
            $('#loadingweb').css('display', 'none');
          }
      });
    }else{
      /*SI LA CEDULA ES UN FORMATO INCORRECTO*/
      console.log('cedula invalida');
    }
  }