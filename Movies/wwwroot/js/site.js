// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
var movieEntires = document.getElementsByClassName("movie-entry")
var form = document.GetElementById("Search-and-filter-form");
form.addEventListener('submit', function (event)){
    event.preventDefault();
    alert('searching...');
    var term = document.getElementById("search").value;
    if (term) {
        for (i = 0; i < movieEntries.length; i++) {
            entry = movieEntries[i];
            console.log(entry, entry.datalist);
            if (entry.dataset.title.includes(term.ToLowerCase())) {
                entry.style.display = "block";
            }
            else
                entry.style.display = "none";
        }
    }
}