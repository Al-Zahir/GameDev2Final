#pragma strict

var anim : Animation;

function Start () {

}

function Update () {

}

function LoadLevel(){
	Debug.Log("Load Tha Level");
}

function ClickStart(){
	animation.Play();
	StartCoroutine("WaitBeforeLoad");
}

function WaitBeforeLoad(){
	yield WaitForSeconds(1);
	LoadLevel();
}

function ClickInstructions(){
	animation.Play();
	anim.Play("Move in instruct");
}

function Back(){
	anim.Play("Move out instruct");
	animation.Play("Move in");
}

function ClickedCredits(){
	Debug.Log("Load Credits");
}