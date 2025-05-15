<template>
    <el-card style="width: 210px; height: auto; border-radius: 12px; display: flex; flex-direction: column; justify-content: space-between; overflow: hidden;"
  :body-style="{ padding: '0px' }">
        <div style="display: flex; justify-content: center; align-items: center; position: relative;">
            <img src="https://shadow.elemecdn.com/app/element/hamburger.9cf7b091-55e9-11e9-a976-7f4d0b07eef6.png"
                class="image" style="display: block; margin: 0 auto; width: 100%;">
        </div>
        <div style="padding: 5px;">
            <h2 style="text-align: center; font-size: 15px;">{{ nome }}</h2>
            <p style="text-align: center; font-size: 12px; color: #999;">{{ quantidade }} itens</p>
        </div>
        

    </el-card>

</template>

<script>

export default{
    props: {
        nome: {
            type: String,
            required: true
        },
        quantidade: {
            type: Number,
            required: true
        }
    }
}
</script>
