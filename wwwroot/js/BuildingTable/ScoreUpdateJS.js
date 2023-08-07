
<script src="https://cdn.ckeditor.com/ckeditor5/39.0.0/classic/ckeditor.js"></script>


let editor;

ClassicEditor
    .create(document.querySelector('#txt_HTMLContent'))
    .then(newEditor => {
        editor = newEditor;
    })
    .catch(error => {
        console.error(error);
    });


function clickRow (obj) {

    try {

        //alert(' am clicked == ' + $('#popupModalEditor'));

        //jQuery.noConflict();
        $('#popupModalEditor').modal('show');

    }

    catch (ex) {
        alert(ex);

    }
}



function readValue (obj) {

    try {

        // var divTestMe = document.getElementById('divTestMe');
        // var divTestMe = document.getElementById('txt_HTMLContent');
        // var divTestMe = document.getElementById('iScoreAdjusted');

        //   alert(divTestMe.innerHTML);
        //alert(divTestMe.textContent);
        //   alert(divTestMe.innerHTML);

        //   alert($("#txt_HTMLContent").val());

        //  alert( ClassicEditor.instances[ 'txt_HTMLContent' ].getData());

        alert(editor.getData());

        //jQuery.noConflict();
        //$('#popupModalEditor').modal('show');

    }

    catch (ex) {
        alert(ex);

    }
}




window.bldtknid;
window.inftknid;
window.clmscore;
window.clmrisk;

function Popup_PostForm () {

    try {

        //alert('inftknid == ' + window.inftknid);

        var clmn_Score = $("[data-clmscore='clmscore_" + inftknid + "']");
        var clmn_RiskMeasure = $("[data-clmrisk='clmrisk_" + inftknid + "']");

        var txt_RiskControlMeasure = '0';
        var visible_RiskControlMeasure = '0';

        if (editor.getData() == '') {
            txt_RiskControlMeasure = "0";
            visible_RiskControlMeasure = "";
        }
        else {
            txt_RiskControlMeasure = editor.getData();
            visible_RiskControlMeasure = editor.getData();

        }

        var iScoreAdjusted = document.getElementById('iScoreAdjusted');



        $.ajax({
            type: "POST",

            //url: @Url.Action("Update_Score_ByInformationTokenID","Development",new { Area = "iWebMember" }),
            url: '/iWebMember/Development/Update_Score_ByInformationTokenID',

            data: {
                iBuildingTokenID: bldtknid,
                iInformationTokenID: inftknid,
                iScoreAdjusted: iScoreAdjusted.value,
                iRiskControlMeasure: txt_RiskControlMeasure
            },
            success: function (result) {


                clmn_Score.html(iScoreAdjusted.value);
                clmn_RiskMeasure.html(visible_RiskControlMeasure);

            },
            error: function () {
                alert('Failed to receive the Data');
                console.log('Failed ');
            }
        });




        $('#popupModalEditor').modal('hide');







        //////$.ajax({
        //////    url: "/iWebMember/Development/GetImage",
        //////    type: 'POST',
        //////    //dataType: 'json',
        //////    data: { divhtml: $("#div_diagram").html() },
        //////    success: function (data) { }
        //////});










        //////   // var divTestMe = document.getElementById('divTestMe');
        //////var divTestMe = document.getElementById('txt_HTMLContent');

        ////// //   alert(divTestMe.innerHTML);
        //////    alert(divTestMe.textContent);

        //////    //jQuery.noConflict();
        //////    //$('#popupModalEditor').modal('show');

    }

    catch (ex) {
        alert(ex);

    }
}



function Popup_LoadForm (bldtknid, inftknid, clmscore, clmrisk) {

    try {


        window.bldtknid = bldtknid;
        window.inftknid = inftknid;
        window.clmscore = clmscore;
        window.clmrisk = clmrisk;

        //alert('popup form here' + bldtknid + " , " + inftknid + " , " + clmscore + " , " + clmrisk);

        var clmn_Score = $("[data-clmscore='clmscore_" + inftknid + "']");
        var clmn_RiskMeasure = $("[data-clmrisk='clmrisk_" + inftknid + "']");

        var txt_RiskControlMeasure = '0';

        if (editor.getData() == '') {
            txt_RiskControlMeasure = "0";
        }
        else {
            txt_RiskControlMeasure = editor.getData();

        }


        //////if (editor.getData() == '') {
        //////    txt_RiskControlMeasure = "0";
        //////}
        //////else {
        //////    txt_RiskControlMeasure = editor.getData();

        //////}

        ////////alert(clmn_Score.html());

        //
        //
        //   alert($("[data-clmnscore='clmscore_1689793069675']").html());



        //var divTestMe = document.getElementById('txt_HTMLContent');
        var iScoreAdjusted = document.getElementById('iScoreAdjusted');

        //  iScoreAdjusted.value = '3';
        iScoreAdjusted.value = clmn_Score.html();

        editor.setData(clmn_RiskMeasure.html());


        //var txt_HTMLContent = document.getElementById('txt_HTMLContent');
        // txt_HTMLContent.value = 'txt_HTMLContent 333';

        //alert(divTestMe.innerHTML);
        //  alert(divTestMe.textContent);
        // alert('updatd popup value == ' + bldtknid);

        //  var editorData =  ClassicEditor.instances[ 'txt_HTMLContent' ];

        //  CKEDITOR.ClassicEditor.instances[ 'txt_HTMLContent' ].setData('txt_HTMLContent 333');



        //  alert(editorData);



        $('#popupModalEditor').modal('show');


        //clmn_Score.html('112');
        //clmn_RiskMeasure.html('<p> Some text 123 hello world </p>');

        // var txt_HTMLContent = document.getElementById('txt_HTMLContent');
        //  txt_HTMLContent.innerHTML = 'txt_HTMLContent 333';


        //  $('#txt_HTMLContent').val('some_value');
        //   $("#main").val(text);

        // alert(divTestMe.textContent);







        //////$.ajax({
        //////    type: "POST",

        //////    //url: @Url.Action("Update_Score_ByInformationTokenID","Development",new { Area = "iWebMember" }),
        //////    url: '/iWebMember/Development/Update_Score_ByInformationTokenID',

        //////    data: {
        //////        iBuildingTokenID: bldtknid,
        //////        iInformationTokenID: bldtknid,
        //////        iScoreAdjusted: bldtknid,
        //////        iRiskControlMeasure: inftknid
        //////    },
        //////    success: function (result) {
        //////        //alert('Successfully received Data ');
        //////        //console.log(result);
        //////        document.getElementById("popup_FormContent").innerHTML = result;
        //////        $('#popupModalEditor').modal('show');
        //////    },
        //////    error: function () {
        //////        alert('Failed to receive the Data');
        //////        console.log('Failed ');
        //////    }
        //////});






        //////$.ajax({
        //////    type: "GET",

        //////    //url: @Url.Action("Popup_GetEditor","BSRVemcoPopup",new { Area = "iWebMember" }),
        //////    url: '/iWebMember/BSRVemcoPopup/Popup_GetEditor',

        //////    data: {
        //////        bldtknid: bldtknid,
        //////        inftknid: inftknid
        //////    },
        //////    success: function (result) {
        //////        //alert('Successfully received Data ');
        //////        //console.log(result);
        //////        document.getElementById("popup_FormContent").innerHTML = result;
        //////        $('#popupModalEditor').modal('show');
        //////    },
        //////    error: function () {
        //////        alert('Failed to receive the Data');
        //////        console.log('Failed ');
        //////    }
        //////});






        //    $.ajax({

        //        type: 'get',

        //        url: @Url.Action("Popup_GetEditor","BSRVemcoPopup",new { Area = "iWebMember" }),//'/Controller/Method',
        //        data: {
        //             bldtknid: bldtknid,
        //            inftknid: inftknid
        //        },
        //        success: function (result) {

        //            alert("result == " + result);

        //            //  document.getElementById("popup_FormContent").innerHTML= result;


        //        }

        //    });
        //});

        // $('#popupModalEditor').modal('show');



        //////    //////$.ajax({
        //////    //////    type: 'GET',
        //////    //////    url: '/Controller/Method',
        //////    //////    data: { ParamName: document.getElementById("DivId").innerHTML },
        //////    //////    success: function (result) {

        //////    //////    }
        //////    //////});
        //////});








        //////   // var divTestMe = document.getElementById('divTestMe');
        //////var divTestMe = document.getElementById('txt_HTMLContent');

        ////// //   alert(divTestMe.innerHTML);
        //////    alert(divTestMe.textContent);

        //////    //jQuery.noConflict();
        //////    //$('#popupModalEditor').modal('show');

    }

    catch (ex) {
        //  alert(ex);
        console.log(ex);
    }
}






$(document).ready(function () {






});

