/// <reference path="~Script/angular.intellisense.js" />
/// <reference path=""../angular.js""/>
/// <reference path=""JSModule.js""/>

//Declaring Service
app.service('ngservice', function ($http) {
  
    //The function to read all Books
    this.getBooks = function () {
        var res = $http.get("api/Books/GetBooks");
        return res;
    };
    //The function to read Books based on filter and its value
    //The function reads all records if value is not entered
    //Else based on the filter and its value, the Books will be returned
    this.getfilteredData = function (filter, value) {
        var res;
        res = 0;
        if (value.length === 0||value===null|| filter.length===0||filter===null) {
            res = $http.get("api/Books/GetBooks");
            return res;
        } else {
            res = $http.get("Books/" + filter + "/" + value);
            return res;
        }

    };
    this.AddBook = function (book) {
        var response = $http({
            method: "post",
            url: "api/Books/AddBook",
            data: JSON.stringify(book),
            dataType: "json",
            contentType: "application/json"
        });
        return response;
    }; 
});




