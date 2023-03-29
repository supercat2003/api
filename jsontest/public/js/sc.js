const xValuesArea = [];
const yValuesArea = [];

const xValuesAreaNewData = [];
const yValuesAreaNewData = [];

$(document).ready(async function(){
    const response = await fetch(
        'http://127.0.0.1:30511/api/S1v1');
    console.log(response);
    const dataRes = await response.json();
    console.log(dataRes);
    length = dataRes.length;
    console.log(length);

    for (let i = 0; i < length; i++) {
        xValuesArea.push(dataRes[i].h);
        yValuesArea.push(dataRes[i].v);
    }


    const responseNewData = await fetch(
        'http://127.0.0.1:30511/api/S1v2');
    console.log(responseNewData);
    const dataResNewData = await responseNewData.json();
    console.log(dataResNewData);
    length = dataResNewData.length;
    console.log(length);

    for (let i = 0; i < length; i++) {
        xValuesAreaNewData.push(dataResNewData[i].h);
        yValuesAreaNewData.push(dataResNewData[i].v);
    }

    const data = {
        labels : xValuesArea,
        datasets : [
            {
                fillColor : "rgba(220,220,220,0.5)",
                strokeColor : "rgba(220,220,220,1)",
                pointColor : "rgba(220,220,220,1)",
                pointStrokeColor : "#fff",
                data : yValuesArea
            }
        ]
    }

    const updateData = function(oldData){
        const labels = oldData["labels"];
        const dataSetA = oldData["datasets"][0]["data"];

        labels.shift();
        labels.push(xValuesAreaNewData);
        dataSetA.push(yValuesAreaNewData);
        dataSetA.shift();
    };

    const ctx = document.getElementById("myChart").getContext("2d");
    const myNewChart = new Chart(ctx);
    myNewChart.Line(data);

    setInterval(function(){
        updateData(data);
        myNewChart.Line(data)
        ;}, 2000
    );
});
