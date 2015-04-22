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
  	CameraMovement();
    PCMouseWheelZoom();
    
    #if UNITY_ANDROID || UNITY_IOS	
    AndroidPinchZoom();
    #endif
}

function CameraMovement(){
	  if (target && Input.GetMouseButton(1)==true) {
	   	calculateCoordinates();
	   	var rotation=CalculateRotation();
		var position=CalculatePosition(rotation);     
	    MakeCameraMovement(rotation,position);
	}
}

function calculateCoordinates(){
	 x += Input.GetAxis("Mouse X") * xSpeed * 0.02;
     y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02;
 	 y = ClampAngle(y, yMinLimit, yMaxLimit);
}

static function ClampAngle (angle : float, min : float, max : float) {
	if (angle < -360)
		angle += 360;
	if (angle > 360)
		angle -= 360;
	return Mathf.Clamp (angle, min, max);
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
       	var touches=GetTouches();
       	// Find the position in the previous frame of each touch.
       	var touchesPreviousPositions=TouchesDeltaPositions(touches);
        // Find the magnitude of the vector (the distance) between the touches in each frame.
       	var deltaMagnitudeDiff=DistanceBetweenTouches(touchesPreviousPositions,touches);
   		MakeCameraAndroidZoom(deltaMagnitudeDiff);
    }
}

function GetTouches(){
	var touchZero = Input.GetTouch(0);
	var touchOne = Input.GetTouch(1);
	var touches=[touchZero, touchOne];
	return touches;
}

function TouchesDeltaPositions(touches: Touch[]){
    var touchZeroPrevPos = touches[0].position - touches[0].deltaPosition;
    var touchOnePrevPos = touches[1].position - touches[1].deltaPosition;
    var touchesPreviousPositions=[touchZeroPrevPos, touchOnePrevPos];
    return touchesPreviousPositions;
}

function DistanceBetweenTouches(touchesPreviousPositions: Vector2[], touches: Touch[]){
 	var prevTouchDeltaMag = (touchesPreviousPositions[0] - touchesPreviousPositions[1]).magnitude;
    var touchDeltaMag = (touches[0].position - touches[1].position).magnitude;
    
    // Find the difference in the distances between each frame.
    var deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
    return deltaMagnitudeDiff;
}

function MakeCameraAndroidZoom(deltaMagnitudeDiff:float){
	//change the field of view based on the change in distance between the touches.
    camera.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;
    
    // Clamp the field of view to make sure it's between 0 and 180.
    camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 0.1f, 179.9f);
        
}