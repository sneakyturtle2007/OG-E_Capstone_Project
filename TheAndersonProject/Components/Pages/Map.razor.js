var map;
var markerElements;
var elementLocations = [];
export function MapInit(elements, siteLocations) {
    map = L.map('map').setView([35.548087971615125, -97.50602842324439], 7);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        mazxZoom: 19,
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);
    for(let i = 0; i < elements.length; i++){
        console.log("Adding siteName: " + elements[i].SiteName);
        AddElement(elements[i], siteLocations[i]);
    }
    return elementLocations;
}

export function AddElement(siteName, elementCoor){
    let coordinates;
    if(elementCoor){
      coordinates = [elementCoor[0], elementCoor[1]];
    }else{
      coordinates = [RandNum(34.8, 36.8531), RandNum(-101.9515, -94.4914)];
    }
    var Icon = L.icon({
        iconUrl: 'img/Site.jpg',
        iconSize: [30, 55],
    });
    var markerElement = L.marker(coordinates, {icon: Icon}, {title: siteName}).addTo(map);
    markerElement.on('click', function(e) {
        if(siteName && map && map.remove){
            
            DotNet.invokeMethodAsync('TheAndersonProject', 'SelectSite', siteName);
            window.location.reload();
            DeleteMap();
            
        }
    });
    markerElement.bindTooltip(siteName, {permanent: true, direction:'center', offset: [0, -47], className:"elementTitle"}).openTooltip();

    elementLocations.push(coordinates);
}
export function DeleteMap(){
    if(map && map.remove){
        map.off();
        map.remove();
    }
}
export function RandNum(min, max){
    return Math.random() * (max - min) + min;
}

