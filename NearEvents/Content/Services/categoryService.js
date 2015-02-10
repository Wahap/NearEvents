app.service("categoryService", function ($http) {

    //get All Eployee
    this.getCategory = function () {
        return $http.get("Category/GetAll");
    };

    // Update Employee 
    this.updateCat = function (cat) {
        var response = $http({
            method: "post",
            url: "Category/UpdateCategory",
            data: JSON.stringify(cat),
            dataType: "json"
        });
        return response;
    }


    // Add Employee
    this.AddCat = function (cat) {
        var response = $http({
            method: "post",
            url: "Category/AddCategory",
            data: JSON.stringify(cat),
            dataType: "json"
        });
        return response;
    }

    //Delete Employee
    this.DeleteCat = function (categoryId) {
        var response = $http({
            method: "post",
            url: "Category/DeleteCategory",
            params: {
                categoryId: JSON.stringify(categoryId)
            }
        });
        return response;
    }

    // get Employee By Id
    this.editCat = function (categoryId) {
        var response = $http({
            method: "post",
            url: "Category/GetCategoryById",
            params: {
                id: JSON.stringify(categoryId)
            }
        });
        return response;
    }

   
});