/* This script and many more are available free online at
The JavaScript Source!! http://www.javascriptsource.com
Created by: Jim Stiles | www.jdstiles.com */
function startCalc() {
  interval = setInterval("calc()", 1);
}

function numberWithCommas(x) {
  return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

function calc() {
  one = document.autoSumForm.total.value;
  one = parseFloat(one.replace(/,/g, ""));

  two = document.autoSumForm.discount.value;
  two = parseFloat(two.replace(/,/g, ""));

  document.autoSumForm.discount.value = numberWithCommas(two);

  three = one * 1 - two * 1;
  document.autoSumForm.amount_due.value = numberWithCommas(three);

  four = document.autoSumForm.tendered.value;
  four = parseFloat(four.replace(/,/g, ""));
  document.autoSumForm.tendered.value = numberWithCommas(four);

  five = four * 1 - three * 1;
  document.autoSumForm.change.value = numberWithCommas(five);

  if (five >= 0) {
    document.autoSumForm.btnCash.disabled = false;
  } else {
    document.autoSumForm.btnCash.disabled = true;
  }
}
function stopCalc() {
  clearInterval(interval);
}
function myFunction() {
  one = document.autoSumForm.total.value;
  document.autoSumForm.amount_due.value = one;
}
