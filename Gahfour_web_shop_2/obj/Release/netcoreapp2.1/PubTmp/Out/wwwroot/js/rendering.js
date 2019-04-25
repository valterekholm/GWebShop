//data - array of objects
function renderTables(data, imgFolder, currency, detailsController) {
    console.log("renderTables, " + detailsController);
    console.log(data);
    //console.log(data.length);
    //console.log(myCols);

    var len = data.length;

    var domTarget = document.getElementsByClassName("products-grid")[0];

    var tbl = document.createElement("table");
    tbl.id = "products_table";

    var colCount = 0;
    var makeRow = false;
    var row;

    for (var i = 0; i < len; i++) {
        makeRow = (colCount == 0);

        if (makeRow) {
            row = document.createElement("tr");
        }

        var item = data[i];
        var td = document.createElement("td");
        td.className = "product";
        //= item["short_name"];

        //skapa länk
        var linkDetails = document.createElement("a");
        linkDetails.href = detailsController + "/" + item["id"];

        //bild
        var imgDiv = document.createElement("div");

        var img = document.createElement("img");
        img.src = imgFolder + item["img"];
        img.alt = "parfym";
        img.title = item["description"];
        //console.log(img.src);

        if (item["img_vertical"] == "True") {
            img.className = "vertical";//stående bild
        }

        imgDiv.appendChild(img);

        linkDetails.appendChild(imgDiv);
        td.appendChild(linkDetails);//förut imgDiv

        var pr_i = document.createElement("div");
        pr_i.className = "product_info";

        var span1 = document.createElement("span");
        var span2 = document.createElement("span");
        var span3 = document.createElement("span");
        var addToCartBtn = document.createElement("a"); //lägg

        span1.innerHTML = item["short_name"];
        span2.innerHTML = item["size"] + " " + item["size_unit"];
        span3.innerHTML = item["price"] + " " + currency;

        addToCartBtn.href = "#";
        addToCartBtn.innerHTML = "köp";

        span3.className = "price";

        pr_i.appendChild(span1);
        pr_i.appendChild(span2);
        pr_i.appendChild(span3);
        pr_i.appendChild(addToCartBtn);x

        td.appendChild(pr_i);

        row.appendChild(td);

        colCount = (colCount + 1) % myCols;

        if (colCount == 0) {
            tbl.appendChild(row);
        }
    }
    if (colCount != 0) {
        //remaining items == colCount
        //Fill upp row

        for (var i = colCount; i < myCols; i++) {
            var emptyCell = document.createElement("td");
            row.appendChild(emptyCell);
        }
        tbl.appendChild(row);

    }

    console.log(colCount);

    domTarget.appendChild(tbl);

}