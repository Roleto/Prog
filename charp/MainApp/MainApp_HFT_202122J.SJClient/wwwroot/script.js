
let wares = [];
let connection = null;
let waretoupdtade = -1;
getdata();
setupSignalR();


fetch('http://localhost:5025/Warehouse')
    .then(x => x.json())
    .then(y => {
        wares = y;
        console.log(wares)
        display();
    });

//function display() {
//    wares.forEach(t => {
//        document.getElementById('resultarea').innerHTML +=
//            "<tr><td>" + t.id + "</td><td>" + t.name + "</td></tr>"
//        console.log(t.name)
//    });
//}




function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5025/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("WarehouseCreated", (user, message) => {
        getdata();
    });

    connection.on("WarehouseDeleted", (user, message) => {
        getdata();
    });

    connection.on("WarehouseUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:5025/Warehouse')
        .then(x => x.json())
        .then(y => {
            wares = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    wares.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.materialType + "</td><td>" + t.name + "</td><td>" + t.pprice + "</td><td>" + t.quantity + "</td><td>" +
        `<button type="button" onclick="remove(${t.id})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.id})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:5025/Warehouse/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function showupdate(id) {
    document.getElementById('updateformdiv').style.display = 'flex';
    waretoupdtade = id;
    let ware = wares.find(t => t['id'] == id);
    document.getElementById('waremattoupdate').value = ware['materialType'];
    document.getElementById('warenametoupdate').value = ware['name'];
    document.getElementById('warepricetoupdate').value = ware['price'];
    document.getElementById('warequantitytoupdate').value = ware['quantity'];

}
function update() {

    document.getElementById('updateformdiv').style.display = 'none';
    let mat = document.getElementById('waremattoupdate').value;
    let mname = document.getElementById('warenametoupdate').value;
    let pprice = document.getElementById('warepricetoupdate').value;
    let quant = document.getElementById('warequantitytoupdate').value;
    fetch('http://localhost:5025/Warehouse', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                id : waretoupdtade,
                materialType: mat,
                name: mname,
                price: pprice,
                quantity: quant
            })

    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let mat = document.getElementById('waremat').value;
    let mname = document.getElementById('warename').value;
    let pprice = document.getElementById('wareprice').value;
    let quant = document.getElementById('warequantity').value;
    fetch('http://localhost:5025/Warehouse', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                materialType: mat,
                name: mname,
                price: pprice,
                quantity: quant
            }) 

    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}