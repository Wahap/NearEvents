app.controller("categoryCont", function ($scope, categoryService) {
    $scope.divEmployee = false;
    getAllCategory();
    //To Get All Records  
    function getAllCategory() {
        var getData = categoryService.getCategory();
        getData.then(function (cat) {
            $scope.categories = cat.data;
        }, function () {
            alert('Error in getting records');
        });
    }



    $scope.AddUpdateCategory = function () {
        var Category = {
            Name: $scope.Name,
           
            Count: $scope.Count
        };
        var getAction = $scope.Action;

        if (getAction == "Update") {
            Category.Id = $scope.Id;
            var getData = categoryService.updateCat(Category)
            getData.then(function (msg) {
                getAllCategory();
                alert(msg.data);
                $scope.divCategory = false;
            }, function () {
                alert('Error in updating record');
            });
        } else {
            var getData = categoryService.AddCat(Category)
            getData.then(function (msg) {
                getAllCategory();
                alert(msg.data);
                $scope.divCategory = false;
            }, function () {
                alert('Error in adding record');
            });
        }
    }


    $scope.deleteCategory = function (category) {
        var getData = categoryService.DeleteCat(category.Id);
        getData.then(function (msg) {
            getAllCategory();
            alert('Category Deleted');
        }, function () {
            alert('Error in Deleting Record');
        });
    }

    $scope.editCategory = function (category) {
        var getData = categoryService.editCat(category.Id);
        getData.then(function (cat) {
            $scope.category = cat.data;
            $scope.Id = category.Id;
            $scope.Name = category.Name;
         
            $scope.Count = category.Count;
            $scope.Action = "Update";
            $scope.divCategory = true;
        }, function () {
            alert('Error in getting records');
        });
    }


    $scope.AddCategoryDiv = function () {
        ClearFields();
        $scope.Action = "Add";
        $scope.divCategory = true;
    }

    function ClearFields() {
        $scope.id = "";
        $scope.name = "";
      
        $scope.count = "";
    }
});