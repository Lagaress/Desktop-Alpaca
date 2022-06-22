function waitTime()
{
   
    const interval = setInterval(function() {
        changeGif() ; 
    }, 3000);
    
} ;

function changeGif()
{

    let randonNumber = generateRandomNumber() ; 

    if ( randonNumber == 1 )
    {
        document.getElementById('alpaca-image').src="./animations/alpaca.gif";
    }

    else if ( randonNumber == 2 )
    {
        document.getElementById('alpaca-image').src="./animations/alpacaPNG.gif";
    }

    else 
    {
        document.getElementById('alpaca-image').src="./animations/alpaca_left.gif";
    }

}

function generateRandomNumber ()
{
    let difference = 4 - 1 ; 
    let rand = Math.random() ; 
    rand = Math.floor( rand * difference);
    rand = rand + 1;

    return rand;
}

waitTime() ; 

