function removeComment(commentId, userId) {
    fetch(`/details/${userId}/comments/remove/${commentId}`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            
        })
    }).then(() => {
        setTimeout(() => {
            window.location.reload();
        }, 250); 
    });

}  
 
function removeNews(newsId, userId) {
    fetch(`/details/${userId}/news/remove/${newsId}`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({

        })
    }).then(response => response.json()).then(data => {
        if (data.status == "success") {
            window.location.replace(`${window.location.origin}/1`)
        } else {
            return;
        }





        
    });
      
            
       
    

}  