/*global $ */
$(document).ready(function ($) {
	"use strict";

	var masterCheckbox = $("#task-checkbox-master"),
		checkboxes = $(".task-checkbox");

	masterCheckbox.change(function () {
		checkboxes.prop("checked", $(this).prop("checked"));
	});
});