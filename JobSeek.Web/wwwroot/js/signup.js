$(document).ready(() => {
   

    $("#get-started").on("click", (e) => {
        e.preventDefault();
        if ($("#email-form").valid()) {
            const email = $("#email").val();
            $("#email-form-container").remove();
            $("#register-form").show();
            $("#signup-email-form").val(email);

             setState();

        }
        
    });

    $('#country').on("change", async () => {
        setState();
    })
})

const setState = async () => {
        const stateContainer = $("#state-container");
        let stateElement = $("#state")
        let stateValidation = $("#state-validation")
        const countryID = $('#country').find(":selected").val();
        const states = await getStates(Number(countryID));

        if (states.length <= 0) {
            stateElement.replaceWith(`<input id="state" name="UserAccountFormModel.StateName" asp-for="UserAccountFormModel.StateName" class="jobseek-primary-input form-control" placeholder="State / Province" />`)
            stateValidation.replaceWith(`<span id="state-validation" asp-validation-for="UserAccountFormModel.StateName" class="text-danger"></span>`)
            return;
        }

        stateElement.empty();


        stateElement.replaceWith(`
            <select id="state" name="UserAccountFormModel.StateID" class="jobseek-primary-input form-select">
                <option value="">Select State</option>
            </select>
        `);
        stateValidation.replaceWith(`<span id="state-validation" asp-validation-for="UserAccountFormModel.StateID" class="text-danger"></span>`)
        stateElement = $("#state");

        states.forEach((s) => {
            stateElement.append(`<option value=${s.stateID}>${s.name}</option>`)
        })


    }

    const getStates = async (id) => {

        if (id !== 39 && id != 233) {
            return [];
        }

        const res = await fetch("/ajax/GetStatesByCountryID?id=" + id);
        const states = await res.json();
        return states
    }