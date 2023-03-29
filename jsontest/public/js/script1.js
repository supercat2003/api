let xValues = [];
let yValues = [];

const xValuesArea2 = [];
const yValuesArea2 = [];

getData();
async function getData() {
    return new Promise((resolve)=> {
        fetch('http://127.0.0.1:30511/api/S1v1').then(
            res=>{
                return res.json()
            })
            .then(data=>{
                console.log(data);
                length = data.length;
                for (let i = 0; i < length; i++) {
                    xValues.push(data[i].h);
                    yValues.push(data[i].v);

                }
            });
            resolve()
    }).then(function () {
        loadScript("https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.5.0/Chart.min.js")
            .then(data => {
                console.log("Script loaded successfully", data);
            })
            .catch(err => {
                console.error(err);
            });
    })
    .then(function (){
            loadScript("https://code.jquery.com/jquery-1.12.0.min.js")
                .then(data => {
                    console.log("Script loaded successfully", data);
                })
                .catch(err => {
                    console.error(err);
                });
        }).then(function () {
        fetch('http://127.0.0.1:30511/api/S1v2').then(
            res=>res.json()
        ).then(data=>{
            console.log(data);
            length = data.length;
            for (let i = 0; i < length; i++) {
                xValuesArea2.push(data[i].h);
                yValuesArea2.push(data[i].v);

            }
        }).then(function (){
            const  ctx = document.getElementById("myChart");
            new Chart(ctx, {
                    type: "line",
                    data: {
                        labels: xValues,
                        datasets: [{
                            backgroundColor: "rgba(0,0,255,0.5)",
                            borderColor: "rgba(0,0,0,0.1)",
                            data: yValues
                        }]
                    },
                    options: {
                        legend: {display: false},
                        title: {
                            display: true,
                            text: "Район №1",
                            fontSize: 16
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
                            fontSize: 16
                        }
                    },
                }
            )
        });
    }).catch(error=>console.log(error));
}

// loadScript("https://js.arcgis.com/4.26/")
//     .then(data => {
//         console.log("Script loaded successfully", data);
//     })
//     .catch(err => {
//         console.error(err);
//     });


const loadScript = (FILE_URL, async = true) => {
    return new Promise((resolve, reject) => {
        try {
            const scriptEle = document.createElement("script");
            // scriptEle.type = type;
            scriptEle.async = async;
            scriptEle.src =FILE_URL;

            scriptEle.addEventListener("load", () => {
                resolve({ status: true });
            });

            scriptEle.addEventListener("error", () => {
                reject({
                    status: false,
                    message: `Failed to load the script ＄{FILE_URL}`
                });
            });

            document.body.appendChild(scriptEle);
        } catch (error) {
            reject(error);
        }
    });
};
