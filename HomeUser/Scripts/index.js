

$(function() {

  $(document).on("click", function(e) {
    var $item = $(".vci-dropmenu-item");
    if ($item.hasClass("active")) {
      $item.removeClass("active");
    }
   
     
  });

  $(".vci-toggle-btn").on('click', function() {
    $(".vci-sidebar").toggleClass("vci-nav-min");
    $(".vci-body-wrapper").toggleClass("vci-nav-min");
      });

  $(".vci-dropdown >.vci-menu-item").on('click', function(e) {
    e.stopPropagation();
    $(".vci-dropmenu-item").removeClass("active");
    $(this).next(".vci-dropmenu-item").toggleClass("active");
  });

 
});

 
 
 