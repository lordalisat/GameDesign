//and add them up top as a public variable.

public var rearCamera : Camera ;
public var driverCamera : Camera ;
public var whereCamera : Camera ;

rearCamera.GetComponent.<Camera>().enabled = true;
driverCamera.GetComponent.<Camera>().enabled = false;
whereCamera.GetComponent.<Camera>().enabled = false;

function Start() {
    {
        rearCamera.GetComponent.<Camera>().enabled = false;
        whereCamera.GetComponent.<Camera>().enabled = false;
        driverCamera.GetComponent.<Camera>().enabled = true;

    }
}

function Update() {
    //this is a hard wired connection to the "F1" Key on the keyboard, switch it any keyboard key if you like
    //this will disable the camera inside of the car, and enable the camera outside of the vehicle
    if (Input.GetKey(KeyCode.P))
    {
        rearCamera.GetComponent.<Camera>().enabled = false;
        driverCamera.GetComponent.<Camera>().enabled = true;
        whereCamera.GetComponent.<Camera>().enabled = false;

    }
    //this is a hard wired connection to the "F2" Key on the keyboard, switch it any keyboard key if you like
    //this will disable the camera behind the car, and enable the camera inside of the vehicle
    if (Input.GetKey(KeyCode.L))
    {
        driverCamera.GetComponent.<Camera>().enabled = false;
        rearCamera.GetComponent.<Camera>().enabled = true;
        whereCamera.GetComponent.<Camera>().enabled = false;
    }

    if (Input.GetKey(KeyCode.M))
    {
    driverCamera.GetComponent.<Camera>().enabled = false;
        rearCamera.GetComponent.<Camera>().enabled = false;
        whereCamera.GetComponent.<Camera>().enabled = true;
    }
}