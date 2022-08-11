eval("console.log(this)");

//console.log(this == global);

function func() {
    eval("console.log(this)");

    //console.log(this == global);
}

new func();

func();

func.call(null);