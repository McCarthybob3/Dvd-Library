$(document).ready(function () {
$('#add-form').hide();

 loadDvds();


$('#search-button').click(function (event){
$('#DVDTableDiv').hide();
loadSearchoptions();
});

  $('#cancel-delete-button').click(function (event) {
$('#delete-confirmation').hide();
$('#DVDTableDiv').show();
  });


  $('#create-button').click(function (event) {
$('#add-form').show();
$('#DVDTableDiv').hide();
  });

 $('#cancel-add-button').click(function (event) {
hideaddForm();

  });

   $('#add-button').click(function (event) {

        $.ajax({
            type: 'POST',
            url: 'http://localhost:58472/dvd',
            data: JSON.stringify({
                title: $('#add-title').val(),
                director: $('#add-director').val(),
                realeaseYear: $('#add-release-date').val(),
                rating: $('#add-rating').val(),
                notes: $('#add-notes').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function() {
              
                $('#errorMessages').empty();
              
                $('#add-title').val('');
                $('#add-director').val('');
                $('#add-release-date').val('');
                $('#add-rating').val('');
                $('#add-notes').val('');
                loadDvds();
            },
            error: function() {
                $('#errorMessages')
                   .append($('<li>')
                   .attr({class: 'list-group-item list-group-item-danger'})
                   .text('Error calling web service.  Please try again later.'));
            }
});
    });

 // Update Button onclick handler
    $('#Update').click(function (event) {

        

      
        $.ajax({
           type: 'PUT',
           url: 'http://localhost:58472/dvd/' + $('#edit-DVD-id').val(),
           data: JSON.stringify({
           	    dvdId: $('#edit-DVD-id').val(),
                title: $('#edit-title').val(),
                director: $('#edit-director').val(),
                realeaseYear: $('#edit-release-date').val(),
                rating: $('#edit-rating').val(),
                notes: $('#edit-notes').val()
           }),
           headers: {
             'Accept': 'application/json',
             'Content-Type': 'application/json'
           },
           'dataType': 'json',
            success: function() {
                // clear errorMessages
                $('#errorMessages').empty();
                hideEditForm();
               loadDvds();
           },
           error: function() {
             $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service.  Please try again later.'));
           }
       })
    });
  


});










function loadDvds() {

 
clearDVDTable();
   
    var contentRows = $('#contentRows');

    $.ajax ({
        type: 'GET',
        url: 'http://localhost:58472/dvds',
        success: function (data, status) {
            $.each(data, function (index, dvd) {
                var title = dvd.title;
                var date = dvd.realeaseYear;
 				var director = dvd.director;
                var rating = dvd.rating;
                var notes = dvd.notes
                var id = dvd.dvdId;


                var row = '<tr>';
                    row += '<td>' + title + '</td>';
                    row += '<td>' + date + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
					

                    row += '<td><a onclick="showEditForm(' + id + ')">Edit</a> '+'|'+'<a onclick="showDeleteConfirmation( '+id+ ')">Delete</a> </td>';
                   
                    row += '</tr>';
                contentRows.append(row);
                hideaddForm();
            });
        },
        error: function() {
            $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service.  Please try again later.'));
        }
    });
}

function hideEditForm() {
    
    $('#errorMessages').empty();
  
    $('#edit-title').val('');
    $('#edit-director').val('');
    $('#edit-release-date').val('');
    $('#edit-rating').val('');
    $('#edit-notes').val('');
    $('#editFormDiv').hide();
    $('#DVDTableDiv').show();
}
function hideaddForm() {
  
    $('#errorMessages').empty();
  
    $('#edit-title').val('');
    $('#edit-director').val('');
    $('#edit-release-date').val('');
    $('#edit-rating').val('');
    $('#edit-notes').val('');
    $('#add-form').hide();
    $('#DVDTableDiv').show();
}
function clearDVDTable() {
    $('#contentRows').empty();
}
function deleteDVD(dvdId) {
    $.ajax ({
        type: 'DELETE',
        url: "http://localhost:58472/dvd/" + dvdId,
        success: function (status) {
            loadDvds();
        }
    });
}
function showEditForm(dvdId) {
    // clear errorMessages
    $('#errorMessages').empty();
    // get the contact details from the server and then fill and show the
    // form on success
    $.ajax({
        type: 'GET',
        url: 'http://localhost:58472/dvd/' + dvdId,
        success: function(data, status) {
        	$('#edit-DVD-id').val(dvdId);
        	  $('#edit-title').val(data.title);
    $('#edit-director').val(data.director);
    $('#edit-release-date').val(data.realeaseYear);
    $('#edit-rating').val(data.rating);
    $('#edit-notes').val(data.notes);
          
          },
          error: function() {
            $('#errorMessages')
               .append($('<li>')
               .attr({class: 'list-group-item list-group-item-danger'})
               .text('Error calling web service.  Please try again later.'));
          }
    });
    $('#dvdTableDiv').hide();
    $('#editFormDiv').show();
}

function showDeleteConfirmation(dvdId){
 $('#DVDTableDiv').hide();
 $('#delete-confirmation').show();	

  $('#delete-confirmation-button').click(function (event) {
  	deleteDVD(dvdId);
$('#delete-confirmation').hide();
$('#DVDTableDiv').show();
  });
}

function loadSearchoptions(){






//edit later


clearDVDTable();
   
    var contentRows = $('#contentRows');

var select = $( "#search-selection option:selected" ).text(); 
var search = $( "#search-input" ).val();




    $.ajax ({
        type: 'GET',
        url: 'http://localhost:58472/dvds/'+select+'/'+search,
        success: function (data, status) {
            $.each(data, function (index, dvd) {
                var title = dvd.title;
                var date = dvd.realeaseYear;
 				var director = dvd.director;
               var rating = dvd.rating;
                var notes = dvd.notes
                var id = dvd.dvdId;


                var row = '<tr>';
                    row += '<td>' + title + '</td>';
                    row += '<td>' + date + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
					

                    row += '<td><a onclick="showEditForm(' + id + ')">Edit</a> '+'|'+'<a onclick="showDeleteConfirmation( '+id+ ')">Delete</a> </td>';
                   
                    row += '</tr>';
                contentRows.append(row);
                hideaddForm();
            });
        },
        error: function() {
            $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service.  Please try again later.'));
        }
    });
}

//<a onclick="deleteDVD(' + id + ')