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
 
