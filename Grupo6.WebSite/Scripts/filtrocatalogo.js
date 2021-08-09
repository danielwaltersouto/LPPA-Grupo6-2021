$(document).ready(function () {

    $('category-list .category-item[category="all"]').addClass('ct_item-active');

    $('.category-item').click(function() {
        var catProduct = $(this).attr('category');
        console.log(catProduct);

        //AGREGAR CLASE AL PRODUCTO SELECCIONADO
        $('.category-item').removeClass('ct_item-active');
        $(this).addClass('ct_item-active');

        //OCULTAR PRODUCTOS
        $('.product-item').css('transform', 'scale(0)');
        function hideProduct() {
            $('.product-item').hide();    
        } setTimeout(hideProduct, 200);            

        //MOSTRAR PRODUCTOS
        function showProduct() {
            $('.product-item[category="' + catProduct + '"]').show();
            $('.product-item[category="' + catProduct + '"]').css('transform', 'scale(1)');
        } setTimeout(showProduct, 200);       
    });

    //MOSTRAR TODOS
    $('.category-item[category="all"]').click(function () {

        function showAll() {
            $('.product-item').show();
            $('.product-item').css('transform', 'scale(1)');
        } setTimeout(showAll, 200);       
    });
});