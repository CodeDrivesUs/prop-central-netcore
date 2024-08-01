

$(function () {
    $("#wizard").steps({
        headerTag: "h4",
        bodyTag: "section",
        transitionEffect: "fade",
        enableAllSteps: true,
        transitionEffectSpeed: 500,
        onStepChanging: function (event, currentIndex, newIndex) {
            if (currentIndex === 0) {
                populateroomtypes();
            }
            if (currentIndex === 1) {
               
                review();
            }
            if (newIndex === 1) {
                $('.steps ul').addClass('step-2');
            } else {
                $('.steps ul').removeClass('step-2');
            }
            if (newIndex === 2) {
                $('.steps ul').addClass('step-3');
            } else {
                $('.steps ul').removeClass('step-3');
            }

            if (newIndex === 3) {
                $('.steps ul').addClass('step-4');
                $('.actions ul').addClass('step-last');
                submitform();
            } else {
                $('.steps ul').removeClass('step-4');
                $('.actions ul').removeClass('step-last');
            }
            if (newIndex === 4) {
                console.log("Testing The submit  to change the photos");
            }
            return true;
        },
        onFinished: function (event, currentIndex) {
            Finished();
            
        },
        labels: {
            finish: "Add Pictures",
            next: "Next",
            previous: "Previous",
            loading: "Loading ...",
            current: "current step:",
            pagination: "Pagination",
        }
    });
    // Custom Steps Jquery Steps
    $('.wizard > .steps li a').click(function () {
        $(this).parent().addClass('checked');
        $(this).parent().prevAll().addClass('checked');
        $(this).parent().nextAll().removeClass('checked');
    });
    // Custom Button Jquery Steps
    $('.forward').click(function () {
        $("#wizard").steps('next');
    })
    $('.backward').click(function () {
        $("#wizard").steps('previous');
    })
    // Checkbox
    $('.checkbox-circle label').click(function () {
        $('.checkbox-circle label').removeClass('active');
        $(this).addClass('active');
    })
})

 function populateroomtypes() {
        var data= [];
        jQuery("input[name='RoomTypes']").each(function () {
          
            if (this.checked === true) {
                            
                data.push(this.value);
            }
        });
        $.post("/FlatsHome/GetSelectedRoomTypes",
            {
                roomtypeId: data
            },
            function (response) {
                console.log(response);
                $("#room_template").html(response);
            });
}

function populatedepositprices() {
    $(function () {
       
        jQuery("input[name='DepositRooms']").each(function () {
            var value = "&DepositWithIds=" + this.id + "|" + this.value;
            console.log("current:"+ ConcatinatedUrlDeposit.concat(value));
        });
    });
}

  function review() {
    var ConcatinatedUrl = [];
   
    jQuery("input[name='RentRooms']").each(function () {
        var value = "RentWithIds=" + this.id + "|" + this.value;
        ConcatinatedUrl.push(value);
    });
    jQuery("input[name='DepositRooms']").each(function () {
        var value = "DepositWithIds=" + this.id + "|" + this.value;
        ConcatinatedUrl.push(value);
    });
    var data = $("#application_form").serialize()+"&" + ConcatinatedUrl.join('&');
      $.post("/FlatsHome/ReviewApplication",
        data,
        function (response) {
            $("#flat_preview").html(response);
        });
}

   function submitform() {
    var ConcatinatedUrl = [];
    jQuery("input[name='RentRooms']").each(function () {
        var value = "RentWithIds=" + this.id + "|" + this.value;
        ConcatinatedUrl.push(value);
    });
    jQuery("input[name='DepositRooms']").each(function () {
        var value = "DepositWithIds=" + this.id + "|" + this.value;
        ConcatinatedUrl.push(value);
    });
    var data = $("#application_form").serialize() + "&" + ConcatinatedUrl.join('&');
       $.post("/FlatsHome/SubmitApplication",
        data,
        function (response) {
            $("#FlatId").val(response);
        });
}

 function Finished() {
    var flatId = $("#FlatId").val();
    window.location.replace("/Camara/FlatDashBord/?FlatId=" + flatId);
}

function populateamenities(name) {
    var value = $("#display_amenity").val();
    if (value == null) {
        $("#display_amenity").val(name);
    }
    else {
        $("#display_amenity").val("," + name);
    }
}
