//To create a confirm prompt in sweetalert
$(".sweetalert-confirmPrompt").on("click", () => {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire({
                title: "Deleted!",
                text: "Your file has been deleted.",
                icon: "success"
            });
        } else {
            Swal.fire({
                title: "Cancelled",
                text: "Your imaginary file is safe :)",
                icon: "error"
            });
        }
    });
})

$(".sweetalert-ajaxRequest").on("click", () => {
    Swal.fire({
        title: "Submit your Github username",
        input: "text",
        inputAttributes: {
            autocapitalize: "off"
        },
        showCancelButton: true,
        confirmButtonText: "Look up",
        showLoaderOnConfirm: true,
        preConfirm: async (login) => {
            try {
                const githubUrl = `
        https://api.github.com/users/${login}
      `;
                const response = await fetch(githubUrl);
                if (!response.ok) {
                    return Swal.showValidationMessage(`
          ${JSON.stringify(await response.json())}
        `);
                }
                return response.json();
            } catch (error) {
                Swal.showValidationMessage(`
        Request failed: ${error}
      `);
            }
        },
        allowOutsideClick: () => !Swal.isLoading()
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire({
                title: `${result.value.login}'s avatar`,
                imageUrl: result.value.avatar_url
            });
        } 
    });
})

$(".sweetalert-customHtml").on("click", () => {
    Swal.fire({
        title: "<strong>HTML <u>example</u></strong>",
        icon: "info",
        html: `
    You can use <b>bold text</b>,
    <a href="#" autofocus>links</a>,
    and other HTML tags
  `,
        showCloseButton: true,
        showCancelButton: true,
        focusConfirm: false,
        confirmButtonText: `
    <i class="fa fa-thumbs-up"></i> Great!
  `,
        confirmButtonAriaLabel: "Thumbs up, great!",
        cancelButtonText: `
    <i class="fa fa-thumbs-down"></i>
  `,
        cancelButtonAriaLabel: "Thumbs down"
    });
})