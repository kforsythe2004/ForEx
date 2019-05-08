window.onload = function () {
    if ($("#listData").length) {
        var dataVue = new Vue({
            el: '#listData',
            data: {
                items: [
                    { name: '', countryCode: '', assets: '' }
                ],
            },
            methods: {

                setData: function (data) {
                    this.items = data;
                    this.items = Object.assign({}, this.items, data);
                },
                getData: function () {

                    $.ajax({
                        type: "GET",
                        crossDomain: true,
                        dataType: 'json',
                        url: "https://kf-forex.azurewebsites.net/home/getdata"
                    }).done(function (data) {
                        dataVue.setData(data);
                    })
                        .fail(function () {
                            alert("error in javascript");
                        });
                }
            }
        });

        //Get Data for both stations and images

        dataVue.getData();
    }

    if ($("#listPorts").length) {
        var portVue = new Vue({
            el: '#listPorts',
            data: {
                items: [
                    { name: '', title: '', assets: '' }
                ],
            },
            methods: {

                setPorts: function (data) {
                    this.items = data;
                    this.items = Object.assign({}, this.items, data);
                },
                getPorts: function () {

                    $.ajax({
                        type: "GET",
                        crossDomain: true,
                        dataType: 'json',
                        url: "https://kf-forex.azurewebsites.net/home/getportfolios"
                    }).done(function (data) {
                        portVue.setPorts(data);
                    })
                        .fail(function () {
                            alert("error in javascript");
                        });
                }
            }
        });

        //Get Data for both stations and images

        portVue.getPorts();
    }


    if ($("#listCurs").length) {
        var curVue = new Vue({
            el: '#listCurs',
            data: {
                items: [
                    { isoCode: '', name: '', symbol: '' }
                ],
            },
            methods: {

                setCurs: function (data) {
                    this.items = data;
                    this.items = Object.assign({}, this.items, data);
                },
                getCurs: function () {

                    $.ajax({
                        type: "GET",
                        crossDomain: true,
                        dataType: 'json',
                        url: "https://kf-forex.azurewebsites.net/home/getcurrency"
                    }).done(function (data) {
                        curVue.setCurs(data);
                    })

                    fail(function () {
                        alert("error in javascript");
                        });
                }
            }
        });

        //Get Data for both stations and images

        curVue.getCurs();
    }


    if ($("#listCntry").length) {
        var cntryVue = new Vue({
            el: '#listCntry',
            data: {
                items: [
                    { code: '', name: '', currencyCode: '' }
                ],
            },
            methods: {

                setCntry: function (data) {
                    this.items = data;
                    this.items = Object.assign({}, this.items, data);
                },
                getCntry: function () {

                    $.ajax({
                        type: "GET",
                        crossDomain: true,
                        dataType: 'json',
                        url: "https://kf-forex.azurewebsites.net/home/getcountries"
                    }).done(function (data) {
                        cntryVue.setCntry(data);
                    })

                    fail(function () {
                        alert("error in javascript");
                    });
                }
            }
        });

        //Get Data for both stations and images

        cntryVue.getCntry();
    }



}

 