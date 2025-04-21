var map;
var markerElements;
var elementLocations = [];
export function MapInit(elementType, elementNames, siteLocations) {
    map = L.map('map').setView([35.548087971615125, -97.50602842324439], 7);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        mazxZoom: 19,
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);
    
    for(let i = 0; i < elementNames.length; i++){
        AddElement(elementType, elementNames[i].toString(), siteLocations[i]);
    }
    return elementLocations;
}
export function AddElement(elementType, elementName, elementCoor){
    var Icon = L.icon({
        iconUrl: 'img/Site.jpg',
        iconSize: [30, 55],
    });

    switch(elementType){
        case "Reader":
            Icon = new Icon({iconURL: 'img/Reader.jpg'});
            break;
        case "Panel":
            Icon = new Icon({iconURL: 'img/Panel.jpg'});
            break;
        default:
            break;
    }
    let coordinates;
    if(elementCoor){
      coordinates = [elementCoor[0], elementCoor[1]];
    }else{
      coordinates = [RandNum(34.3489, 36.8531), RandNum(-101.9515, -94.4914)];
    }
    var markerElement = L.marker(coordinates, {icon: Icon}, {title: elementName}).addTo(map);
    markerElement.on('click', function(e) {
        alert("Marker clicked!");
    });
    markerElement.bindTooltip(elementName, {permanent: true, direction:'center', offset: [0, -47], className:"elementTitle"}).openTooltip();

    elementLocations.push(coordinates);
}
export function RandNum(min, max){
    return Math.random() * (max - min) + min;
}
