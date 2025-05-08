var map;
var markerElements;
var elementLocations = [];
var zoomLevel;
export function MapInit(elements, siteLocations) {
    map = L.map('map').setView([35.548087971615125, -97.50602842324439], 7);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        mazxZoom: 19,
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);
    map.on('zoomend', function(e){
        zoomLevel = e.getZoom();
    });
    for(let i = 0; i < elements.length; i++){
        console.log("Adding elementName: " + elements[i].SiteName);
        AddElement(elements[i], siteLocations[i], "sites", i);
    }
    return elementLocations;
}
export function SiteInit(readers, panels, elementCoordinates){
    elementLocations =  [];
    var bounds = [[0,0],[800, 1000]]
    map = L.map('map', {
        crs: L.CRS.Simple,
        minZoom: -0.515,       
        maxZoom: 2,        
        maxBoundsViscosity: 1.0,
        zoomControl: false,
    }).setView([500,400], 0.25);
    //L.imageOverlay('img/BuildingBlueprint.jpg', bounds).addTo(map);
    L.control.zoom({
        position: 'topright',
        zoomInText: '+',
        zoomOutText: '-'
    }).addTo(map);
    map.setMaxBounds(bounds);
    
    for(let i = 0; i < readers.length; i++){
        AddElement(readers[i], elementCoordinates[i], "readers", i);
    }
    for(let i = 0; i < panels.length; i++){
        AddElement(panels[i], elementCoordinates[i + readers.length], "panels", i + readers.length);
    }
    return elementLocations;
}
export function AddElement(elementName, elementCoor, category, index){
    var Icon;
    let toolTipOffset;
    switch(category){
        case "readers":
            Icon = L.icon({
                iconUrl: 'img/Reader.jpg',
                iconSize: [25, 25],
            });
            toolTipOffset = [0, -25];
            break;
        case "panels":
            Icon = L.icon({
                iconUrl: 'img/Panel.jpg',
                iconSize: [25, 40],
            });
            toolTipOffset = [0, -35];
            break;
        default:
            Icon = L.icon({
                iconUrl: 'img/Site.jpg',
                iconSize: [30, 55],
            });
            toolTipOffset = [0, -47];
            break;
    }
    let coordinates;
    if(elementCoor){
        coordinates = [elementCoor[0], elementCoor[1]];
    }else{
        if(category == "sites"){
            coordinates = [RandNum(34.8, 36.8531), RandNum(-101.9515, -94.4914)];
        }else{
            coordinates = [RandNum(200, 750), RandNum(100, 900)];

        }
    }
    
    var markerElement = L.marker(coordinates,{draggable: 'true', icon: Icon, title: elementName.toString()}).addTo(map);
    markerElement.on('click', function(e) {
        if(elementName && map && map.remove){
            
            DotNet.invokeMethodAsync('TheAndersonProject', 'SelectElement', elementName.toString(), category);
            window.location.reload();
            map.setZoom(zoomLevel);
            DeleteMap();
        }
    });
    markerElement.on('dragend', function(event) {
        var marker = event.target;
        var position = marker.getLatLng();
        marker.setLatLng(new L.LatLng(position.lat, position.lng),{draggable:'true', icon: Icon});
        DotNet.invokeMethodAsync('TheAndersonProject', 'UpdateElementLocation', [position.lat, position.lng], index, category);
    });
    
    markerElement.bindTooltip(elementName.toString(), {permanent: true, direction:'center', offset: toolTipOffset}).openTooltip();

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

