export function MapInit(){
    var map = L.map('map').setView([35.548087971615125, -97.50602842324439], 10);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        mazxZoom: 19,
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);
    AddElement(map, "Site");
}
export function AddElement(map, imgName, locationName){
    var Icon = L.icon({
        iconUrl: 'img/Site.jpg',
        iconSize: [30, 55],
    });

    switch(imgName){
        case "reader":
            Icon = new Icon({iconURL: 'img/Reader.jpg'});
            break;
        case "panel":
            Icon = new Icon({iconURL: 'img/Panel.jpg'});
            break;
        default:
            break;
    }
    var marker = L.marker([35.548087971615125, -97.50602842324439], {icon: Icon}).addTo(map);
    marker.on('click', function(e) {
        alert("Marker clicked!");
    });
}