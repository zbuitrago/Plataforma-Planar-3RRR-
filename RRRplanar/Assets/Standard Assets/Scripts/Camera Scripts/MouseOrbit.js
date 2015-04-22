var target : Transform;
var distance = 10.0;

var xSpeed = 250.0;
var ySpeed = 120.0;

var yMinLimit = -20;
var yMaxLimit = 80;

private static var x = 0.0;
private static var y = 0.0;
private var zoomStep=3;

private var perspectiveZoomSpeed : float = 0.5f;            


@script AddComponentMenu("Camera-Control/Mouse Orbit")

function Start () {
    var angles = transform.eulerAngles;
    x = angles.y;
    y = angles.x;

	// Make the rigid body not change rotation
   	if (GetComponent.<Rigidbody>())
		GetComponent.<Rigidbody>().freezeRotation = true;
}

function LateUpdate () {
    if (target && Input.GetMouseButton(1)==true) {
       	calculateCoordinates();
       	var rotation=CalculateRotation();
 		var position=CalculatePosition(rotation);     
        MakeCameraMovement(rotation,position);
    }
    
    PCMouseWheelZoom();

    #if UNITY_ANDROID || UNITY_IOS	
    AndroidPinchZoom();
    #endif
}

function calculateCoordinates(){
	 x += Input.GetAxis("Mouse X") * xSpeed * 0.02;
     y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02;
 	 y = ClampAngle(y, yMinLimit, yMaxLimit);
}

function CalculateRotation(){
	var rotation = Quaternion.Euler(y, x, 0);
	return rotation;
}

function CalculatePosition(rotation: Quaternion){
    var position = rotation * Vector3(0.0, 0.0, -distance) + target.position;
    return position;
}

function  MakeCameraMovement(rotation: Quaternion, position: Vector3){
	 transform.rotation = rotation;
     transform.position = position;
}

function  PCMouseWheelZoom(){
	transform.Translate(Vector3.forward * (Input.GetAxis("Mouse ScrollWheel"))*zoomStep);
}

function AndroidPinchZoom(){
	if (Input.touchCount == 2)
    {
        // Store both touches.
        var touchZero = Input.GetTouch(0);
        var touchOne = Input.GetTouch(1);

        // Find the position in the previous frame of each touch.
        var touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        var touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

        // Find the magnitude of the vector (the distance) between the touches in each frame.
        var prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        var touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

        // Find the difference in the distances between each frame.
        var deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
   
        // Otherwise change the field of view based on the change in distance between the touches.
        camera.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

        // Clamp the field of view to make sure it's between 0 and 180.
        camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 0.1f, 179.9f);
        
    }
}

static function ClampAngle (angle : float, min : float, max : float) {
	if (angle < -360)
		angle += 360;
	if (angle > 360)
		angle -= 360;
	return Mathf.Clamp (angle, min, max);
}