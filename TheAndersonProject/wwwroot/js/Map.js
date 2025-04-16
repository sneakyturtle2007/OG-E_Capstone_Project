function initMap() {
    // Create a new map centered at the specified coordinates
    const map = new google.maps.Map(document.getElementById("map"), {
        center: { lat: 37.7749, lng: -122.4194 }, // San Francisco coordinates
        zoom: 8,
    });

    // Create a marker and set its position
    const marker = new google.maps.Marker({
        position: { lat: 37.7749, lng: -122.4194 },
        map: map,
        title: "Hello San Francisco!",
    });
}