function valid_datas(f) {
    if (f.name.value == '') {
        jQuery('#form_status').html('<span class="wrong">Họ tên không được để trống!</span>');
        notice(f.name);
    } else if (f.email.value == '') {
        jQuery('#form_status').html('<span class="wrong">Email không được để trống và phải đúng định dạng!</span>');
        notice(f.email);
    } else if (f.phone.value == '') {
        jQuery('#form_status').html('<span class="wrong">Số điện thoại không được để trống và phải đúng định dạng!</span>');
        notice(f.phone);
    } else if (f.subject.value == '') {
        jQuery('#form_status').html('<span class="wrong">Vấn đề không được để trống!</span>');
        notice(f.subject);
    } else if (f.message.value == '') {
        jQuery('#form_status').html('<span class="wrong">Câu hỏi không được để trống!</span>');
        notice(f.message);
    } else {
        jQuery.ajax({
            url: 'mail.php', // Make sure to adjust this URL
            type: 'post',
            data: jQuery('form#fruitkha-contact').serialize(),
            success: function (data) {
                jQuery('#form_status').html(data);
                // Clear form fields
                jQuery('form#fruitkha-contact')[0].reset();
                // Reload the page after a delay (you can adjust the delay as needed)
                setTimeout(function () {
                    location.reload();
                }, 3000);
            },
            error: function (xhr, status, error) {
                jQuery('#form_status').html('<span class="wrong">Error submitting the form. Please try again.</span>');
            },
            beforeSend: function () {
                jQuery('#form_status').html('<span class="loading">Đang gửi tin nhắn của bạn...</span>');
                jQuery('#fruitkha-contact').animate({ opacity: 0.3 });
                jQuery('#fruitkha-contact').find('input,textarea,button').css('border', 'none').attr({ 'disabled': '' });
            }
        });
    }

    return false;
}

function notice(f) {
    jQuery('#fruitkha-contact').find('input,textarea').css('border', 'none');
    f.style.border = '1px solid red';
    f.focus();
}