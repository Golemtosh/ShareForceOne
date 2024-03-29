
@*working with click no route*@
@*<script>
        // Note: This example requires that you consent to location sharing when
        // prompted by your browser. If you see the error "The Geolocation service
        // failed.", it means you probably did not give permission for the browser to
        // locate you.
        var map, infoWindow;
        let markersArray = [];

        function initMap() {

            var sundsvall = { lat: 62.39, lng: 17.30 };

            map = new google.maps.Map(document.getElementById('map'), {
                center: sundsvall,
                zoom: 13
                
            });

            map.addListener('click', function (e) {
                console.log(e);
                addMarker(e.latLng);
                

});

infoWindow = new google.maps.InfoWindow;

// Try HTML5 geolocation.
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(function (position) {
                    var pos = {
                        lat: position.coords.latitude,
                        lng: position.coords.longitude
                        
                    };

                    infoWindow.setPosition(pos);
                    //infoWindow.setContent('Location found.');
                    //infoWindow.open(map);

                    let marker = new google.maps.Marker({
                        map: map,
                        position: { lat: position.coords.latitude, lng: position.coords.longitude },
                        draggable: true
                        
                    });


                }, function () {
                    handleLocationError(true, infoWindow, map.getCenter());
                });
            } else {
                // Browser doesn't support Geolocation
                handleLocationError(false, infoWindow, map.getCenter());
            }
        }

        function handleLocationError(browserHasGeolocation, infoWindow, pos) {
            infoWindow.setPosition(pos);
            infoWindow.setContent(browserHasGeolocation ?
                'Error: The Geolocation service failed.' :
                'Error: Your browser doesn\'t support geolocation.');
            infoWindow.open(map);
        }

        // define function to add marker at given lat & lng
        function addMarker(latLng) {
            let marker = new google.maps.Marker({
                map: map,
                position: latLng,
                
                draggable: true
    
});

 
            //store the marker object drawn on map in global array
            markersArray.push(marker);



        }

        function drawPolyline() {
            let markersPositionArray = [];
            // obtain latlng of all markers added on map
            markersArray.forEach(function (e) {
                markersPositionArray.push(e.getPosition());
            });

            // check if there is already polyline drawn on map
            // remove the polyline from map before we draw new one
            if (polyline !== null) {
                polyline.setMap(null);
            }

            // draw new polyline at markers' position
            polyline = new google.maps.Polyline({
                map: map,
                path: markersPositionArray,
                strokeOpacity: 0.4
            });
        }

        // Sets the map on all markers in the array.
        function setMapOnAll(map) {
            for (var i = 0; i < markersArray.length; i++) {
                markersArray[i].setMap(map);
            }
        }
        // Removes the markers from the map, but keeps them in the array.
        function clearMarkers() {
            setMapOnAll(null);
        }


    map.entities.push(driverPosition);
}

    // Shows any markers currently in the array.
        function showMarkers() {
            setMapOnAll(map);
        }

        // Deletes all markers in the array by removing references to them.
        function deleteMarkers() {
            clearMarkers();
            markersArray = [];
        }

    </script>*@

    @*<script>

        let map;
        var infoWindow;
        let markersArray = [];

        function initMap() {

            var sundsvall = { lat: 62.39, lng: 17.30 };
            var lithuania = { lat: 56.39, lng: 23.30 };

            map = new google.maps.Map(document.getElementById('map'), {
                center: sundsvall,
                zoom: 13
            });

            map.addListener('click', function (e) {
                console.log(e);
                addMarker(e.latLng);
               
});
}

infoWindow = new google.maps.InfoWindow;
// Try HTML5 geolocation.
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                var pos = {
                    lat: position.coords.latitude,
                    lng: position.coords.longitude
                };
                infoWindow.setPosition(pos);
                infoWindow.setContent('Location found.');
                infoWindow.open(map);
                map.setCenter(pos);
                map.addMarker(e.latLng)
            }, function () {
                handleLocationError(true, infoWindow, map.getCenter());
            });

        } else {
            // Browser doesn't support Geolocation
            handleLocationError(false, infoWindow, map.getCenter());
        }

        function handleLocationError(browserHasGeolocation, infoWindow, pos) {
                infoWindow.setPosition(pos);
                infoWindow.setContent(browserHasGeolocation ?
                'Error: The Geolocation service failed.' :
                'Error: Your browser doesn\'t support geolocation.');
                infoWindow.open(map);
        }

        // define function to add marker at given lat & lng
        function addMarker(latLng) {
            let marker = new google.maps.Marker({
                map: map,
                position: latLng,
                draggable: true
            });
            //store the marker object drawn on map in global array
            markersArray.push(marker);
        }

        function drawPolyline() {
            let markersPositionArray = [];
            // obtain latlng of all markers added on map
            markersArray.forEach(function (e) {
                markersPositionArray.push(e.getPosition());
            });

            // check if there is already polyline drawn on map
            // remove the polyline from map before we draw new one
            if (polyline !== null) {
                polyline.setMap(null);
            }

            // draw new polyline at markers' position
            polyline = new google.maps.Polyline({
                map: map,
                path: markersPositionArray,
                strokeOpacity: 0.4
            });
        }
    </script>*@



@*<script>
        var map;
        function initMap() {

            var sundsvall = { lat: 62.39, lng: 17.30 };
            var lithuania = { lat: 56.39, lng: 23.30 };

            map = new google.maps.Map(document.getElementById('map'), {
                center: lithuania,
                zoom: 13
            })

            var marker = new google.maps.Marker({position: sundsvall, map: map});

        }
    </script>
*@

@*<script>
        // Note: This example requires that you consent to location sharing when
        // prompted by your browser. If you see the error "The Geolocation service
        // failed.", it means you probably did not give permission for the browser to
        // locate you.
        var map, infoWindow;

        function initMap() {
            map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: -34.397, lng: 150.644 },
                zoom: 6
            });
        }
            infoWindow = new google.maps.InfoWindow;

            // Try HTML5 geolocation.
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(function (position) {
                    var pos = {
                        lat: position.coords.latitude,
                        lng: position.coords.longitude
                    };
                    infoWindow.setPosition(pos);
                    infoWindow.setContent('Location found.');
                    infoWindow.open(map);
                    map.setCenter(pos);
                }, function () {
                    handleLocationError(true, infoWindow, map.getCenter());
                    });

            } else {
                // Browser doesn't support Geolocation
                handleLocationError(false, infoWindow, map.getCenter());
            }

            map.addListener('click', function (e) {
                console.log(e);
                addMarker(e.latLng);
            }

        function handleLocationError(browserHasGeolocation, infoWindow, pos) {
            infoWindow.setPosition(pos);
            infoWindow.setContent(browserHasGeolocation ?
            'Error: The Geolocation service failed.' :
            'Error: Your browser doesn\'t support geolocation.');
            infoWindow.open(map);
        }

        // define function to add marker at given lat & lng
      function addMarker(latLng) {
        let marker = new google.maps.Marker({
            map: map,
            position: latLng,
            draggable: true
        });
        //store the marker object drawn on map in global array
        markersArray.push(marker);
      }

    </script>*@


//<div id="floating-panel">
//    <b>Start: </b>
//    <select id="start">
//        <option value="sundsvall">sundsvall</option>
//        <option value="st louis, mo">St Louis</option>
//        <option value="joplin, mo">Joplin, MO</option>
//        <option value="oklahoma city, ok">Oklahoma City</option>
//        <option value="amarillo, tx">Amarillo</option>
//        <option value="gallup, nm">Gallup, NM</option>
//        <option value="flagstaff, az">Flagstaff, AZ</option>
//        <option value="winona, az">Winona</option>
//        <option value="kingman, az">Kingman</option>
//        <option value="barstow, ca">Barstow</option>
//        <option value="san bernardino, ca">San Bernardino</option>
//        <option value="los angeles, ca">Los Angeles</option>
//    </select>
//    <b>End: </b>
//    <select id="end">
//        <option value="stockholm">stockholm</option>
//        <option value="stockholm">stockholm</option>
//        <option value="joplin, mo">Joplin, MO</option>
//        <option value="oklahoma city, ok">Oklahoma City</option>
//        <option value="amarillo, tx">Amarillo</option>
//        <option value="gallup, nm">Gallup, NM</option>
//        <option value="flagstaff, az">Flagstaff, AZ</option>
//        <option value="winona, az">Winona</option>
//        <option value="kingman, az">Kingman</option>
//        <option value="barstow, ca">Barstow</option>
//        <option value="san bernardino, ca">San Bernardino</option>
//        <option value="los angeles, ca">Los Angeles</option>
//    </select>
//</div>