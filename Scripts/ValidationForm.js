
//validation function

function valideInfo(regex, value){

    if (regex.test(value))
           { console.log(value)
            return true;}
        else return false;
}

function validate(){
const username = document.querySelector('#username').value;
const password = document.querySelector('#password').value;
document.querySelector('#userResult').innerHTML = '';
document.querySelector('#passResult').innerHTML = '';
var validate = true;

var re = /^[1-3]{0,4}$/g;
var strResultUser ='';
var strResultPass ='';


//validate if username have [1-3]{0,4}

var result = username.match(re);

    if(!result){

         strResultUser =  strResultUser+"you can not have a sequence " ;
        document.querySelector('#userResult').innerHTML = strResultUser + username;
        return validate = false;
       
    }

//validate if password have [1-3]{0,4}

var resultpass = password.match(re);
    if(!resultpass){
     
         strResultPass =  strResultPass + "you can not have a sequence " ;
        document.querySelector('#passResult').innerHTML = strResultPass + password;
        return validate = false;
      
    } 

//verify if it's a bot
var time1= Date.now();
var random = randomString();
var trying=0;
while(trying<3){
var randomVf = prompt("Please entrer the value : "+random);
    if(randomVf==null || randomVf =="" || randomVf!=random){
        trying++;
            
             if(trying==3){
                blockBot();
                return false;}
            }
break;
        }
var time2= Date.now();
//Stril verify if it's a bot
   if( !timeSpan(time1,time2)){
        return false;
             blockBot();
        }
return validate;
}



function randomString() {
    var chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXTZabcdefghiklmnopqrstuvwxyz";
    var string_length = Math.floor(Math.random() * 10) + 6;
    var randomstring = '';
    for (var i=0; i<string_length; i++) {
        var rnum = Math.floor(Math.random() * chars.length);
        randomstring += chars.substring(rnum,rnum+1);
    }
    return randomstring;
}

function timeSpan(time1,time2){
    var time = (time2-time1)/1000;
    if(time<1)
        return false;
       else return true;
}

function blockBot(){
    var w = screen.width;
    var h = screen.height;
    var div = "<div styel='display:block; position:fixed;top:0;left:0;width:"+ (w+10)+"px; height:"+(h+10)+"px;' >we have a problem contact the administrator</div>";
    document.body.innerHTML=div;
}