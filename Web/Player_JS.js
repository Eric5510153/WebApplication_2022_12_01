var book = document.getElementById("book");
var audio = document.getElementById("myAudio");
var controlPanel = document.getElementById("controlPanel");
var btnArea = document.getElementById("btnArea");
var info = document.getElementById("info");
var marquee = document.getElementById("marquee")
var setVolValue = document.getElementById("setVolValue");
var volValue = document.getElementById("volValue");
var progress = document.getElementById("progress");
var music = document.getElementById("music");

console.log(btnArea.children[6]);

let btnPlay = btnArea.children[0];
let btnMuted = btnMute.children[0];


function showBook() {
    book.className = book.className == "" ? "hide" : "";
}

var option;
for (var i = 0; i < book.children[0].children.length; i++) {
    book.children[0].children[i].draggable = "true";
    book.children[0].children[i].id = "song" + i;


    book.children[0].children[i].ondragstart = drag;

    option = document.createElement("option");


    option.value = book.children[0].children[i].title;
    option.innerText = book.children[0].children[i].innerText;
    music.appendChild(option);
}
changeMusic(0);


function updateMusic() {


    for (var i = music.children.length - 1; i >= 0; i--) {
        music.remove(i);
    }


    for (var i = 0; i < book.children[1].children.length; i++) {

        option = document.createElement("option");


        option.value = book.children[1].children[i].title;
        option.innerText = book.children[1].children[i].innerText;
        music.appendChild(option);
    }


    changeMusic(0);
}



function allowDrop(ev) {
    ev.preventDefault();
}


function drag(ev) {
    ev.dataTransfer.setData("aaa", ev.target.id);
}


function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("aaa");

    if (ev.target.id == "")
        ev.target.appendChild(document.getElementById(data));
    else
        ev.target.parentNode.appendChild(document.getElementById(data));

}

//全曲循環
function setAllLoop() {
    info.children[2].innerText = info.children[2].innerText == "全曲循環" ? "一般播放" : "全曲循環";
}


//隨機播放
function setRandom() {
    info.children[2].innerText = info.children[2].innerText == "隨機播放" ? "一般播放" : "隨機播放";
}


//單曲循環
function setLoop() {
    info.children[2].innerText = info.children[2].innerText == "單曲循環" ? "一般播放" : "單曲循環";
}



function changeMusic(i) {

    audio.children[0].src = music.options[music.selectedIndex + i].value;
    audio.children[0].title = music.options[music.selectedIndex + i].innerText;
    music.options[music.selectedIndex + i].selected = true;
    audio.load();

    if (btnPlay.innerText == ";")
        playPlayer();
}



function setProgressBar() {
    audio.currentTime = progress.value;
}



var min = 0, sec = 0;
function getTimeFormat(timeSec) {

    min = parseInt(timeSec / 60);
    sec = parseInt(timeSec % 60);
    min = min < 10 ? "0" + min : min;
    sec = sec < 10 ? "0" + sec : sec;

    return min + ":" + sec;
}


var w = 0;
var r = 0;
getDuration();
function getDuration() {
    info.children[1].innerText = getTimeFormat(audio.currentTime) + " / " + getTimeFormat(audio.duration);

    w = audio.currentTime / audio.duration * 100;
    console.log(w);
    progress.style.backgroundImage = "-webkit-linear-gradient(left,#46A3FF,#0000E3 " + w + "%, #46A3FF " + w + "% ,#46A3FF)";;
    progress.max = parseInt(audio.duration);
    progress.value = parseInt(audio.currentTime);



    if (audio.currentTime == audio.duration) {

        console.log(info.children[2].innerText == "單曲循環");
        if (info.children[2].innerText == "單曲循環")
            changeMusic(0);
        else if (info.children[2].innerText == "隨機播放") {

            r = Math.floor(Math.random() * music.options.length);
            console.log("r=" + r);
            r = r - music.selectedIndex;

            changeMusic(r);
        }

        else if (music.selectedIndex == music.options.length - 1) {
            if (info.children[2].innerText == "全曲循環")
                changeMusic(-music.selectedIndex);
            else
                stopAudio();
        }

        else
            changeMusic(1);
    }




    setTimeout(getDuration, 50);

}

setVolume();
//音量調整
function setVolume() {
    volValue.value = setVolValue.value;
    audio.volume = setVolValue.value / 100;

    setVolValue.style.backgroundImage = "-webkit-linear-gradient(left,#0000E3,#46A3FF,#8600FF " + setVolValue.value + "%,  #00FFFF " + setVolValue.value + "% , #80FFFF)";
}

//音量微調
function btnSetVolume(vol) {
    setVolValue.value = parseInt(volValue.value) + vol;
    setVolume();
}


//設定靜音
function setMuted() {
    audio.muted = !audio.muted;
    let muteImage = document.getElementById('btnMute');
    if (audio.muted) {
        muteImage.src = 'PLAYER_PHOTO/SP_MUTE.png'
    }
    if (!audio.muted) {
        muteImage.src = 'PLAYER_PHOTO/SPEAKER.png'
    }

}


//快轉及倒轉
function changeTime(sec) {
    audio.currentTime += sec;
}


//音樂播放
function playPlayer() {
    audio.play();
    btnPlay.innerText = ";";
    btnPlay.onclick = pausePlayer;
    marquee.children[0].innerText = "現正播放:" + audio.children[0].title;

}

//音樂暫停
function pausePlayer() {
    audio.pause();
    btnPlay.innerText = "4";
    btnPlay.onclick = playPlayer;
    marquee.children[0].innerText = "音樂暫停";
}

//音樂停止
function stopAudio() {
    pausePlayer();
    audio.currentTime = 0;
    marquee.children[0].innerText = "音樂停止";
}