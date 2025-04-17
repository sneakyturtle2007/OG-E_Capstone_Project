var map;
var markerElements;
export function MapInit(elementNames, elementType){
    map = L.map('map').setView([35.548087971615125, -97.50602842324439], 10);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        mazxZoom: 19,
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);
    markerElements  = L.markerClusterGroup();
    
    for(let i = 0; i < elementNames.length; i++){
        AddElement(elementType, elementNames[i]);
    }

}
export function RefreshMap(elementNames, elementType){
    for(let i = 0; i < elementNames.length; i++){
        AddElement(elementType, elementNames[i]);
    }
}
export function AddElement(imgName, siteName){
    var Icon = L.icon({
        iconUrl: 'img/Site.jpg',
        iconSize: [30, 55],
    });

    switch(imgName){
        case "Reader":
            Icon = new Icon({iconURL: 'img/Reader.jpg'});
            break;
        case "Panel":
            Icon = new Icon({iconURL: 'img/Panel.jpg'});
            break;
        default:
            break;
    }
    let coordinates = [RandNum(33.3489, 36.8531), RandNum(-102.9515, -94.4914)];
    
    var marker = L.marker(coordinates, {icon: Icon}, {title: siteName});
    
    marker.on('click', function(e) {
        alert("Marker clicked!");
    });

    markerElements.addLayer(marker);
}
export function RandNum(min, max){
    return Math.random() * (max - min) + min;
}