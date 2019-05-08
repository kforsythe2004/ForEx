window.onload = function () {
    if ($("#listData").length) {
        var dataVue = new Vue({
            el: '#listData',
            data: {
                items: [
                    { name: 'key', title: 'title', assets: 'fx' }
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
                        url: "https://localhost:44381/home/getdata"
                    }).done(function (data) {
                        dataVue.seData(data);
                    })
                        .fail(function (error) {
                            alert(error);
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
                    { name: 'key', title: 'title', assets: 'fx' }
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
                        url: "https://localhost:44381/home/getportfolios"
                    }).done(function (data) {
                        portVue.setPorts(data);
                    })
                        .fail(function (error) {
                            alert(error);
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
                    { isoCode: 'isoCode', name: 'name', symbol: 'symbol' }
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
                        url: "https://localhost:44381/home/getcurrency"
                    }).done(function (data) {
                        curVue.setCurs(data);
                    })

                    fail(function (error) {
                            alert(error);
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
                    { code: 'Code', name: 'name', currencyCode: 'cur' }
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
                        url: "https://localhost:44381/home/getcountries"
                    }).done(function (data) {
                        cntryVue.setCntry(data);
                    })

                    fail(function (error) {
                        alert(error);
                    });
                }
            }
        });

        //Get Data for both stations and images

        cntryVue.getCntry();
    }



}

 