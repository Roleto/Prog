<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('generalstores', function (Blueprint $table) {
            $table->id("Id");
            $table->Integer('MaterialId');
            $table->string('Name');
            $table->boolean('Damaged');
            $table->Integer('Quality');
            $table->Integer('BasePrice');            
            $table->Integer('ExpiringDate')->nullable();
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('generalstores');
    }
};
