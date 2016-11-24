// <reference path="~Script/angular.intellisense.js" />
/// <reference path=""../angular.js""/>
/// <reference path=""JSModule.js""/>

//Declaring the Controller
app.controller('ngcontroller', function ($scope, ngservice, $http, $window, $rootScope) {
    $scope.Selectors = ["","Author", "Title"];
    $scope.SelectedCriteria = ""; 
    $scope.filterValue = ""; 
    $scope.Books = "";
    $scope.Message = "";
    $scope.delbook = "";

    // reset Insert values
    $scope.resetImportValues = function () {
        $scope.bookTitle = "",
        $scope.bookAuthor = "",
        $scope.Year = "",
        $scope.Price = "",
        $scope.Genre = "",
        $scope.Annotation = "",
        $scope.Image = "";
    };
  
    //Function  to Load all Books
    function loadBooks() {
        var promises = ngservice.getBooks();
        promises.then(function (resp) {
            $scope.Books = resp.data;
            $scope.Message = "Call is getBooks Completed Successfully";
        }, function (err) {
            $scope.Message = "Call Failed loadBooks" + err.status;
        });
    }
  
 
    //Function to Load Books based on criteria
    $scope.getFilteredData = function () {
        var promise = ngservice.getfilteredData($scope.SelectedCriteria, $scope.filterValue);
        promise.then(function (resp) {
            $scope.Books = resp.data;
            $scope.Message = "Call is getFiltereddata Completed Successfully";
        }, function (err) {
            $scope.Message = "Call Failed getFilteredData" + err.status+err.Message;
        });
    };
   

    $scope.Addbook = function () {
        var Book = {
            Title:      $scope.bookTitle,
            Author:     $scope.bookAuthor,
            Year:       $scope.Year,
            Price:      $scope.Price,
            Genre:      $scope.Genre,
            Annotation: $scope.Annotation,
            Image:      $scope.Image.base64
        };
       
        var getBookData = ngservice.AddBook(Book);     
        getBookData.then(function (resp) {
            $scope.Books = resp.data;
            $scope.Message = "Call is getBooks After Add Completed Successfully";
        }, function (err) {
            $scope.Books = "";
            $scope.Message = "Call Failed loadBooks" + err.status;
        });    
    };


    //Delete operation
    $scope.delete = function (book) {
        $http({
            method: "DELETE",
            url: "api/Books/DeleteBook",
            params: {Id: book.Id},
            dataType: "json",
            contentType: "application/json"
        }).then(function successCallback(response) {       
            alert("Product Deleted Successfully !!!");
            loadBooks();
        }, function errorCallback(response) {
            alert("Error : " + response.data.ExceptionMessage);
        });
    };



    $scope.clear = function () {
        $scope.edbook.Id = '';
        $scope.edbook.Title = '';
        $scope.edbook.Author = '';
        $scope.edbook.Year = '';
        $scope.edbook.Price = '';
        $scope.edbook.Genre = '';
        $scope.edbook.Annotation = '';
        $scope.edbook.Image = '';
    };

    // Edit Book details
    $scope.edit = function (data) {
        $scope.edbook = { Id: data.Id, Title: data.Title, Author: data.Author, Year: data.Year, Price: data.Price, Genre: data.Genre, Annotation: data.Annotation};
    };

    // Update Book details
    $scope.update = function () {
        if ($scope.edbook.Title !== "" &&
       $scope.edbook.Price !== "" && $scope.edbook.Genre !== "") {
            $http({
                method: 'PUT',
                url: 'api/Books/PutBook', 
                data: $scope.edbook
            }).then(function successCallback(response) {
                $scope.Books = response.data;
                $scope.clear();
                alert("Product Updated Successfully !!!");
            }, function errorCallback(response) {
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
        else {
            alert('Please Enter All the Values !!');
        }
    };
    loadBooks();

});

