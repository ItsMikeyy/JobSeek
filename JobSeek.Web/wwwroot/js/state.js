$(document).ready(() => {
   
    //For signup page
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
    });


    setState();
});

const setState = async () => {
    const countryElement = $("#country");
    const stateContainer = $("#state-container");
    if (countryElement.length === 0 || stateContainer.length === 0) {
        return;
    }

    const form = stateContainer.closest("form");

    const stateEl = $("#state");
    const currentStateValue = stateEl.val();
    const stateTextName = countryElement.data("state-text-name") || stateEl.attr("name") || "StateName";
    const stateSelectName = countryElement.data("state-select-name") || stateEl.attr("name") || "StateID";

    const countryID = Number(countryElement.find(":selected").val());
    const states = await getStates(countryID);

    if (!states || states.length <= 0) {
        // Free text for non-US/Canada countries
        stateContainer.find("#state").replaceWith(
            `<input id="state" name="${stateTextName}" type="text" class="jobseek-primary-input form-control" placeholder="State / Province" />`
        );
        stateContainer.find("#state-validation").replaceWith(
            `<span id="state-validation" data-valmsg-for="${stateTextName}" data-valmsg-replace="true" class="text-danger"></span>`
        );

        if (currentStateValue) {
            $("#state").val(currentStateValue);
        }

        reparseValidation(form);
        return;
    }

    stateContainer.find("#state").replaceWith(
        `<select id="state" name="${stateSelectName}" class="jobseek-primary-input form-select">
            <option value="">Select State</option>
        </select>`
    );
    stateContainer.find("#state-validation").replaceWith(
        `<span id="state-validation" data-valmsg-for="${stateSelectName}" data-valmsg-replace="true" class="text-danger"></span>`
    );

    const stateElement = $("#state");
    states.forEach((s) => {
        const optionValue = (stateSelectName || "").toLowerCase().includes("stateid") ? s.stateID : s.name;
        stateElement.append(`<option value="${optionValue}">${s.name}</option>`);
    });

    reparseValidation(form);
};

const US_COUNTRY_ID = 233;
const CANADA_COUNTRY_ID = 39;

const getStates = async (countryId) => {
    if (countryId !== CANADA_COUNTRY_ID && countryId !== US_COUNTRY_ID) {
        return [];
    }

    const res = await fetch("/ajax/GetStatesByCountryID?id=" + countryId);
    if (!res.ok) {
        return [];
    }
    return await res.json();
};

const reparseValidation = (form) => {
    if (!form || form.length === 0) return;
    if ($.validator && $.validator.unobtrusive) {
        $.validator.unobtrusive.parse(form);
    }
};