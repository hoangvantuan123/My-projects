document.addEventListener('DOMContentLoaded', init, false);

var DataApi = 'http://localhost:3000/DATA'


function init() {
    let table = document.getElementById('table');
    fetch(DataApi)
        .then(function (response) {
            return response.json();
        })
        .then(function (DATA) {
            let result = '';
            DATA.forEach(c => {
                result += `<tr>
                    <td>${c.STT}</td>
                    <td>${c.MSV}</td>
                    <td>${c.Name +" "+ c.FIELD4}</td>
                    <td>${c.Age}</td>
                    <td>${c.Class}</td>
                </tr>`;
            });
            table.innerHTML = result;
        })
}