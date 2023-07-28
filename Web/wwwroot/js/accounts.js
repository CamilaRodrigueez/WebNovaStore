var listaAccounts = [];
let codCliente = '';

$(document).ready(function () {
    getAllAccounts();
});
function getAllAccounts() {
    modalProcessing(true);
    $.ajax({
        url: '/Account/GetAllAccounts',
        method: 'GET',
        dataType: "json",
        success: function (data) {
            modalProcessing(false);
            console.log(data);
            if (data.isSuccess) {
                listaAccounts = data.result;
                loadGrid(listaAccounts);
                console.log(listaAccounts);
            } else {
                Swal.fire(
                    'Opps!',
                    data.message,
                    'error');
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            modalProcessing(false);
            console.error(xhr, textStatus, errorThrown);
        }
    });
}

function loadGrid(data) {
    //llenar registro
    if ($.fn.dataTable.isDataTable('#tblAccounts')) {
        var table = $('#tblAccounts').DataTable();
        table.destroy();
        cargarGridAccounts(data);
        fillDataTable('tblAccounts');
    }
    else {
        cargarGridAccounts(data);
        fillDataTable('tblAccounts');
    }
}

function cargarGridAccounts(data) {
    console.log('Llamada', data);

    $("#bodyAccounts").html("");

    for (var i = 0; i < data.length; i++) {
        var tr = `
                         <tr>
                                    <th>`+ data[i].codCli + `</th>
                                    <th>`+ data[i].tipIde + `</th>
                                    <th> `+ data[i].nitCli + `</th>
                                    <th> `+ data[i].nomCli + `</th>
                                    <th> `+ data[i].eMail + `</th>
                        <td>
                                    <button  class="btn btn-info" onclick="detailAccount(`+ data[i].codCli + `)"><i class="fas fa-eye"></i> Detalle</button>
                         </td>
                        </tr>
                         `;
        $("#bodyAccounts").append(tr);
    }
}


function nuevaAccounts() {
    window.location.href = "Account/Create";
}

function detailAccount(cod) {
    console.log(cod);

    codCliente = cod;
    let accountSelected = listaAccounts.find(x => x.codCli == codCliente);

    $("#txtCodCli").val(accountSelected.codCli);
    $("#txtTipIde").val(accountSelected.tipIde);
    $("#txNitCli").val(accountSelected.nitCli);
    $("#txtNomCli").val(accountSelected.nomCli);
    $("#txtAp1Cli").val(accountSelected.ap1Cli);
    $("#txtNom1Cli").val(accountSelected.nom1Cli);
    $("#txtEmail").val(accountSelected.eMail);
    $("#txtTipPer").val(accountSelected.tipPer);
    $("#txtCodCiu").val(accountSelected.codCiu);
    $("#txtCodDep").val(accountSelected.codDep);
    $("#txtCodPai").val(accountSelected.codPai);
    $("#txtDi1Cli").val(accountSelected.di1Cli);
    $("#txtDi2Cli").val(accountSelected.di2Cli);
    $("#txtTe1Cli").val(accountSelected.te1Cli);
    $("#txtTipCli").val(accountSelected.tipCli);
    $("#txtPagWeb").val(accountSelected.pagWeb);
    //Formateando Fecha 
    let fechaIngreso = accountSelected.fecIng;
    console.log(fechaIngreso);
    var fecha = new Date(fechaIngreso); //Fecha actual
    var mes = fecha.getMonth() + 1; //obteniendo mes
    var dia = fecha.getDate(); //obteniendo dia
    var ano = fecha.getFullYear(); //obteniendo año
    if (dia < 10)
        dia = '0' + dia; //agrega cero si el menor de 10
    if (mes < 10)
        mes = '0' + mes; //agrega cero si el menor de 10
    document.getElementById('txtFechIng').value = ano + "-" + mes + "-" + dia;
   
    $("#txtCodCliExtr").val(accountSelected.codCliExtr);

    const modal = new bootstrap.Modal('#modalAccounts', {
        keyboard: true
    });
    modal.show();
}