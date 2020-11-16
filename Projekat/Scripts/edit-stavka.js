$(document).ready(function () {
    $('.izmijeni-stavku').click(function () {
        var row = $(this).closest('tr.stavka-row');
        
        var stavka_id = row.data('stavka-id');
        var opis = row.find('.opis').data('value');
        var kolicina = row.find('.kolicina').data('value');
        var cijena_bez_pdv = row.find('.cijenabezpdv').data('value');

        $('#Opis').val(opis);
        $('#Kolicina').val(kolicina);
        $('#CijenaBezPDV').val(cijena_bez_pdv);

        $('#StavkaButton').text('Sačuvaj');
        $('#Id').val(stavka_id);
        $('#OtkaziButton').removeClass('hidden');

        event.preventDefault();
    });

    $('#OtkaziButton').click(function () {
        $('#Opis').val("");
        $('#Kolicina').val("");
        $('#CijenaBezPDV').val("");


        $('#StavkaButton').text('Dodaj');
        $('#Id').val("");
        $('#OtkaziButton').addClass('hidden');

        event.preventDefault();
    });
});
