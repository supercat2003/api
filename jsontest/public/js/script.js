const xValuesArea = [];
const yValuesArea = [];

const xValuesArea2 = [];
const yValuesArea2 = [];


window.onload = async function() {
    const response = await fetch(
        'http://127.0.0.1:30511/api/S1v1');
    console.log(response);
    const data = await response.json();
    console.log(data);
    length = data.length;
    console.log(length);

    for (let i = 0; i < length; i++) {
        xValuesArea.push(data[i].h);
        yValuesArea.push(data[i].v);
    }

    const response1 = await fetch(
        'http://127.0.0.1:30511/api/S2v2');
    console.log(response1);
    const data1 = await response1.json();
    console.log(data1);
    length = data1.length;
    console.log(length);

    for (let i = 0; i < length; i++) {
        xValuesArea2.push(data1[i].h);
        yValuesArea2.push(data1[i].v);
    }

    const  ctx = document.getElementById("myChart");

    new Chart(ctx, {
            type: "line",
            data: {
                labels: xValuesArea,
                datasets: [{
                    backgroundColor: "rgba(0,0,255,0.5)",
                    borderColor: "rgba(0,0,0,0.1)",
                    data: yValuesArea
                }]
            },
            options: {
                legend: {display: false},
                title: {
                    display: true,
                    text: "Район №1",
                    fontSize: 25
                }
            },
        }
    )


    const  ctx1 = document.getElementById("myChart1");
    new Chart(ctx1, {
            type: "line",
            data: {
                labels: xValuesArea2,
                datasets: [{
                    backgroundColor: "rgba(255,0,106,0.5)",
                    borderColor: "rgba(0,0,0,0.1)",
                    data: yValuesArea2
                }]
            },
            options: {
                legend: {display: false},
                title: {
                    display: true,
                    text: "Район №2",
                    fontSize: 25
                }
            },
        }
    )
}






