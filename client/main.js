document.addEventListener('DOMContentLoaded', function () {
    // Triggered when the HTML document has fully loaded
    fetchPosts();
});

function fetchPosts() {
    $.ajax({
        url: 'https://localhost:7004/titles',
        method: 'GET',
        dataType: 'json',
        success: function(data) {
            // Successful AJAX request to fetch post titles
            displayTitles(data);
        },
        error: function( error) {
            console.error('Error fetching data:', error);
            // Handle errors when fetching post titles
        }
    });
}

function fetchPost(postId) {
    $.ajax({
        url: 'https://localhost:7004/post/' + postId,
        method: 'GET',
        dataType: 'json',
        success: function(data) {
            // Successful AJAX request to fetch specific post data
            displayPost(data);
        },
        error: function( error) {
            console.error('Error fetching post data:', error);
            // Handle errors when fetching specific post data
        }
    });
}

function displayTitles(data) {
    var postListContainer = $('#postList');

    for (var postId in data) {
        if (data.hasOwnProperty(postId)) {
            var postLink = $('<a class="postLink link-opacity-75"></a>');
            postLink.text(data[postId]);
            postLink.data('post-id', postId);
            postListContainer.append(postLink);

            postLink.on('click', function() {
                var postId = $(this).data('post-id');
                fetchPost(postId);
            });
        }
    }
}




function displayPost(post) {
    // Display the specific post data on the webpage
    var selectedPostContainer = $('#selectedPost');
    selectedPostContainer.empty(); // Clear previous post

    var postElement = $('<div class="card"></div>');
    postElement.html(`
        <h2 class="card-title">${post.title}</h2>
        <p class="card-text">${post.description}</p>
        <a class="btn btn-primary" href='${post.link}' target='_blank'>Read More</a>
        <hr>
    `);
    selectedPostContainer.append(postElement);
}